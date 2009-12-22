using System.Collections.Generic;
using System.IO;
using NHibernate;
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
            const string questionText = "What is the use of 'var' key word?";
            Question question = new Question(questionText);
            Assert.AreEqual(questionText, question.QuestionText);
        }

        [Test]
        public void ShouldBeAbleToGetTheQuestionTag()
        {
            const string questionText = "What is the use of 'var' key word?";
            List<string> tags = new List<string> {"abc", "def"};
            Question question = new Question(questionText, tags);
            Assert.AreEqual(new QuestionTags(tags), question.Tags);
        }

        [Test]
        public void ShouldCreateOneQuestionInDb()
        {
            const string questionText = "What is the use of 'var' key word?";
            Question question = new Question(questionText);
            session.Save(question);
            IQuery query = session.CreateQuery("from Question");
            IList<Question> questions = query.List<Question>();
            Assert.AreEqual(1, questions.Count);
        }

        [Test]
        public void ShouldCollectAnswers()
        {
            Question question = new Question("What is the use of 'var' key word?");
            question.AddAnswer(new Answer(new AskMeDate(), null, "first answer"));
            Assert.AreEqual(1, question.NumberOfAnswers);
            question.AddAnswer(new Answer(new AskMeDate(), null, "second answer"));
            Assert.AreEqual(2, question.NumberOfAnswers);
        }

        [Test]
        public void ShouldSaveAnswersToQuestion()
        {
            const string questionText = "What is the use of 'var' key word?";
            Question question = new Question(questionText);
            question.AddAnswer(AnswerMother.KamalsBadAnswer);
            session.Save(question);
            IQuery query = session.CreateQuery("from Answer");
            IList<Answer> answers = query.List<Answer>();
            Assert.AreEqual(1, answers.Count);
        }
    }
}