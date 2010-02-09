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
            Assert.AreEqual(1,question.GetVotes().GetTotalVotes());
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
        public void ValidateCountOfVotesCasted()
        {
            string questionText = "What is the use of 'var' key word?";
            User owner = new User("shanu", "shanu", "shanu@shanu.com");
            User user1 = new User("user", "user", "shanu@shanu.com");
            User user2 = new User("user2", "user", "shanu@shanu.com");
            User user3 = new User("user3", "user", "shanu@shanu.com");
            Question question = new Question(questionText, owner);

            Assert.AreEqual(questionText, question.QuestionText);

            question.CastVote(QuestionVote.PositiveVote(user1));
            question.CastVote(QuestionVote.PositiveVote(user2));
            question.CastVote(QuestionVote.NegativeVote(user3));
            Repository.GetInstance().SaveUser(user1);
            Repository.GetInstance().SaveUser(user2);
            Repository.GetInstance().SaveUser(user3);
            Repository.GetInstance().SaveQuestion(question);
            Assert.AreEqual(1, Repository.GetInstance().GetTotolVotes(question));//question.GetVotes().GetTotalVotes());
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void ValidateIfSameUserCannotVoteMoreThanOnceForAQuestion()
        {
            string questionText = "What is the use of 'var' key word?";
            User owner = new User("shanu", "shanu", "shanu@shanu.com");
            User user1 = new User("user", "user", "shanu@shanu.com");
            Question question = new Question(questionText, owner);

            Assert.AreEqual(questionText, question.QuestionText);

            question.CastVote(QuestionVote.PositiveVote(user1));
            question.CastVote(QuestionVote.PositiveVote(user1));
            Assert.AreEqual(1, question.GetVotes().GetTotalVotes());
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
        
        [Test]
        public void VerifyThatAnAnswerCouldBeAccepted()
        {
            User user = new User("shanu", "shanu", "shanu@shanu.com");
            Repository repository = Repository.GetInstance();
            repository.SaveUser(user);
            Question question = new Question("What is the use of 'var' key word?", user);

            Answer answer = new Answer(new AskMeDate(), user, "first answer");
            repository.SaveAnswer(answer);
            question.AddAnswer(answer);

            Answer answerToBeAccepted = new Answer(new AskMeDate(), user, "second answer");
            repository.SaveAnswer(answerToBeAccepted);
            question.AddAnswer(answerToBeAccepted);

            question.AcceptSolution(answerToBeAccepted);
            
            repository.SaveQuestion(question);
            Answers answersFound = repository.LoadAnswersForQuestion(question);
            
            Assert.AreEqual(answerToBeAccepted, question.AcceptedAnswer);
        }
        
        [Test]
        [ExpectedException (typeof(NotSupportedException))]
        public void VerifyThatAnAnswerCouldNotBeAcceptedMoreThanOnce()
        {
            User user = new User("shanu", "shanu", "shanu@shanu.com");
            Repository repository = Repository.GetInstance();
            repository.SaveUser(user);
            Question question = new Question("What is the use of 'var' key word?", user);

            Answer answer = new Answer(new AskMeDate(), user, "first answer");
            repository.SaveAnswer(answer);
            question.AddAnswer(answer);

            Answer acceptedAnswer = new Answer(new AskMeDate(), user, "second answer");
            repository.SaveAnswer(acceptedAnswer);
            question.AddAnswer(acceptedAnswer);

            question.AcceptSolution(acceptedAnswer);

            repository.SaveQuestion(question);
            Answers answersFound = repository.LoadAnswersForQuestion(question);
            
            Assert.AreEqual(acceptedAnswer, question.AcceptedAnswer);
            question.AcceptSolution(acceptedAnswer);
            repository.SaveQuestion(question);

        }
        
        [Test]
        [ExpectedException (typeof(NotSupportedException))]
        public void VerifyThatOnlyOneAnswerOfAQuestionCanBeAccepted()
        {
            User user = new User("shanu", "shanu", "shanu@shanu.com");
            Question question = new Question("What is the use of 'var' key word?", user);
            Answer answer1 = new Answer(new AskMeDate(), user, "first answer");
            question.AddAnswer(answer1);

            Answer answer2 = new Answer(new AskMeDate(), user, "second answer");
            question.AddAnswer(answer2);

            question.AcceptSolution(answer1);
            question.AcceptSolution(answer2);

            Repository repository = Repository.GetInstance();
            repository.SaveQuestion(question);
            
        }
        
        [Test]
        public void OwnerCanAcceptAnAnswerForAQuestionRaisedByHim()
        {
            User user = new User("ShilpaG", "test123", "shilpa@foo.com");

            Question question = new Question("What is the use of 'var' key word?", user);
            Repository repository = Repository.GetInstance();
            repository.SaveQuestion(question);
            repository.SaveUser(user);


            Answer answer1 = new Answer(new AskMeDate(), user, "first answer");
            repository.SaveAnswer(answer1);

            question.AddAnswer(answer1);

            user.AcceptAnswer(question, answer1);
            
        }


        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void TestOnlyOwnerCanAcceptAnAnswerForAQuestionRaisedByHim()
        {
            User user = new User("ShilpaG", "test123", "shilpa@foo.com");
            User userOtherThanOwner = new User("Arun", "arun", "arun@foo.com");
            Question question = new Question("What is the use of 'var' key word?", user);
            Answer answer1 = new Answer(new AskMeDate(), null, "first answer");
            question.AddAnswer(answer1);

            userOtherThanOwner.AcceptAnswer(question, answer1);
            Repository repository = Repository.GetInstance();
            repository.SaveQuestion(question);
        }

        [Test]
        public void QuestionOwnerShouldGetTwoPointsOnAcceptingAnAnswer()
        {
            User questioner = new User("ShilpaG", "test123", "shilpa@foo.com");

            Question question = new Question("What is the use of 'var' key word?", questioner);
            Repository repository = Repository.GetInstance();
            repository.SaveQuestion(question);
            repository.SaveUser(questioner);



            User answerer = new User("Ajith", "test123", "ajith@foo.com");
            repository.SaveUser(answerer);

            Answer answer1 = new Answer(new AskMeDate(), answerer, "first answer");
            repository.SaveAnswer(answer1);

            question.AddAnswer(answer1);

            questioner.AcceptAnswer(question, answer1);
            Assert.AreEqual(2, questioner.Points());
        }

        [Test]
        public void AnswererShouldGetTwentyPointsIfQuestionOwnerAcceptsTheAnswer()
        {
            User questioner = new User("ShilpaG", "test123", "shilpa@foo.com");

            Question question = new Question("What is the use of 'var' key word?", questioner);
            Repository repository = Repository.GetInstance();
            repository.SaveQuestion(question);
            repository.SaveUser(questioner);



            User answerer = new User("Ajith", "test123", "ajith@foo.com");
            repository.SaveUser(answerer);

            Answer answer = new Answer(new AskMeDate(), answerer, "first answer");
            repository.SaveAnswer(answer);

            question.AddAnswer(answer);

            questioner.AcceptAnswer(question, answer);
            Assert.AreEqual(20, answerer.Points());
        }
        
        [Test]
        public void ShouldGetOnlyTwoPointsIfQuestionOwnerAcceptsHisOwnAnswer()
        {
            User questionerAndAnswerer = new User("ShilpaG", "test123", "shilpa@foo.com");

            Question question = new Question("What is the use of 'var' key word?", questionerAndAnswerer);
            Repository repository = Repository.GetInstance();
            repository.SaveQuestion(question);
            repository.SaveUser(questionerAndAnswerer);

            Answer answer = new Answer(new AskMeDate(), questionerAndAnswerer, "first answer");
            repository.SaveAnswer(answer);

            question.AddAnswer(answer);

            questionerAndAnswerer.AcceptAnswer(question, answer);
            Assert.AreEqual(2, questionerAndAnswerer.Points());
        }

        [Test]
        public void QuestionerShouldGetTenPointsOnReceivingPositiveVote()
        {
            User questioner = new User("ShilpaG", "test123", "shilpa@foo.com");
            User positiveVoteUser = new User("Ajith", "test123", "shilpa@foo.com");

            Question question = new Question("What is the use of 'var' key word?", questioner);

            question.CastVote(QuestionVote.PositiveVote(positiveVoteUser));
            Assert.AreEqual(10, questioner.Points());
        }

        [Test]
        public void QuestionerShouldGetMinusOnePointOnReceivingNegativeVote()
        {
            User questioner = new User("ShilpaG", "test123", "shilpa@foo.com");
            User negativeVoteUser = new User("Ajith", "test123", "shilpa@foo.com");

            Question question = new Question("What is the use of 'var' key word?", questioner);

            question.CastVote(QuestionVote.NegativeVote(negativeVoteUser));
            Assert.AreEqual(-1, questioner.Points());
        }

      
    }
}