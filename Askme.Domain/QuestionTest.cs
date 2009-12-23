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
        private ISession session;

        [TestFixtureSetUp]
        public void SuiteSetup()
        {
            InitalizeSessionFactory(new FileInfo("Question.hbm.xml"), new FileInfo("Answer.hbm.xml"), new FileInfo("User.hbm.xml"));
        }

        [SetUp]
        public void TestSetup()
        {
            session = CreateSession();
        }

        [Test]
        public void ShouldBeAbleToGetTheQuestionText()
        {
            string questionText = "What is the use of 'var' key word?";
            User user = new User("shanu","shanu","shanu@shanu.com");
            Question question = new Question(questionText,user);
            Assert.AreEqual(questionText,question.QuestionText);
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

            Assert.AreEqual(csharpTag, question.GetTags.Tags[0]);
            Assert.AreEqual(javaTag, question.GetTags.Tags[1]);

        }


        [Test]
        public void ShouldCreateOneQuestionInDb()
        {
            string questionText = "What is the use of 'var' key word?";
            User user = new User("shanu", "shanu", "shanu@shanu.com");
            Question myFirstQuestion = new Question(questionText,user);
            session.Save(myFirstQuestion);
            IQuery query = session.CreateQuery("from Question");
            IList<Question> questions = query.List<Question>();
            Assert.AreEqual(1, questions.Count);
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
            const string questionText = "What is the use of 'var' key word?";
            Question question = new Question(questionText,UserMother.Kamal);
            question.AddAnswer(AnswerMother.KamalsBadAnswer);
            session.Save(question);
            IQuery query = session.CreateQuery("from Answer");
            IList<Answer> answers = query.List<Answer>();
            Assert.AreEqual(1, answers.Count);
        }

        [Test]
        public void ShouldBeAbleToSearchQuestionsBasedOnAKeyword()
        {
            string questionText = "What is the use of 'var' key word?";
            string searchString = "word";
            Question question = new Question(questionText, UserMother.Kamal);
        
            Repository repository = Repository.GetInstance();
            repository.SaveQuestion(question);
            IList<Question> questionsFound = repository.SearchKeyWordInQuestion(searchString);
            
            
         
            Assert.AreEqual(1,questionsFound.Count);

        }
    }
}