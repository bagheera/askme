using System;
using System.Collections.Generic;
using System.IO;
using NHibernate;
using NHibernate.Criterion;
using NUnit.Framework;

namespace Askme.Domain
{
    [TestFixture]
    public class QuestionTest : NHibernateInMemoryBase
    {
       
        [Test]
        public void ShouldBeAbleToGetTheQuestionText()
        {
            string questionText = "What is the use of 'var' key word?";
            User user = new User("shanu","shanu","shanu@shanu.com");
            Question question = new Question(questionText,user);
            Assert.AreEqual(questionText,question.QuestionText);
        }

        [Test]
        public void NonOwnersShouldBeAbleToCastVote()
        {
            string questionText = "What is the use of 'var' key word?";
            User owner = new User("shanu","shanu","shanu@shanu.com");
            User user = new User("user","user","shanu@shanu.com");
            Question question = new Question(questionText,owner);

            Assert.AreEqual(questionText, question.QuestionText);

            question.CastVote(QuestionVote.PositiveVote(user));
            Assert.AreEqual(1,question.GetVotes().Count);
        }

        [Test]
        [ExpectedException(typeof(InvalidDataException))]
        public void QuestionOwnerShouldNotBeAbleToCastVote()
        {
            string questionText = "What is the use of 'var' key word?";
            User owner = new User("shanu","shanu","shanu@shanu.com");
            Question question = new Question(questionText,owner);

            Assert.AreEqual(questionText, question.QuestionText);

            question.CastVote(QuestionVote.PositiveVote(owner));
        }

        [Test]
        public void ShouldBeAbleToCreateQuestionWithTag()
        {
            string questionText = "What is the use of 'var' key word?";
            Tag csharpTag = new Tag("C#");
            Tag javaTag = new Tag("Java");

            User user = new User("shanu", "shanu", "shanu@shanu.com");
            Question question = new Question(questionText,user);
            question.AddTags(csharpTag);
            question.AddTags(javaTag);

            Assert.AreEqual(csharpTag, question.Tags[0]);
            Assert.AreEqual(javaTag, question.Tags[1]);

        }

        [Test]
        public void ShouldCollectAnswers()
        {
            User user = new User("shanu", "shanu", "shanu@shanu.com");
            Question question = new Question("What is the use of 'var' key word?",user);

            question.AddAnswer(new Answer(new AskMeDate(), null, "first answer"));
            Assert.AreEqual(1, question.NumberOfAnswers);
            question.AddAnswer(new Answer(new AskMeDate(), null, "second answer"));
            Assert.AreEqual(2, question.NumberOfAnswers);
        }

        [Test]
        public void ShouldSaveAnswersToQuestion()
        {
            User user = UserMother.Kamal;
            Repository repository = Repository.GetInstance();
            repository.SaveUser(user);
            const string questionText = "What is the use of 'var' key word?";
            Question question = new Question(questionText,user);
            question.AddAnswer(new Answer(new AskMeDate(), user, "this is bad answer"));
            repository.SaveQuestion(question);
            IList<Answer> answers = repository.LoadAnswerForQuestion(question);
            Assert.AreEqual(1, answers.Count);
        }

        [Test]
        public void ShouldBeAbleToSearchQuestionsBasedOnAKeyword()
        {
            string questionText = "What is the use of 'var' key word?";
            string searchString = "word";
            User user = UserMother.Kamal;
            Question question = new Question(questionText, user);
        
            Repository repository = Repository.GetInstance();

            int count = repository.SearchKeyWordInQuestion(searchString).Count;
            repository.SaveUser(user);
            repository.SaveQuestion(question);
            IList<Question> questionsFound = repository.SearchKeyWordInQuestion(searchString);
  
            Assert.AreEqual(count + 1,questionsFound.Count);

        }

        
    }
}