using System;
using System.Collections.Generic;
using System.IO;
using NHibernate;
using NUnit.Framework;

namespace Askme.Domain
{
    [TestFixture]
    public class QuestionTest:NHibernateInMemoryTestFixtureBase
    {
        private ISession session;
        [TestFixtureSetUp]
        public void SuiteSetup()
        {
            InitalizeSessionFactory(new FileInfo("Question.hbm.xml"));
        }

        [SetUp]
        public void TestSetup()
        {
            session = this.CreateSession();
        }

        [Test]
        public void ShouldBeAbleToGetTheQuestionText()
        {
            string questionText = "What is the use of 'var' key word?";
<<<<<<< HEAD
            Question question = new Question(questionText, AskMeDate.CurrentTime);
            Assert.AreEqual(questionText,question.Text);
=======
            Question question = new Question(questionText);
            Assert.AreEqual(questionText,question.QuestionText);
>>>>>>> question
        }
        [Test]
        public void AskedOnDateShouldDefaultToCurrentDateTime()
        {
            string questionText = "What is the use of 'var' key word?";
            AskMeDate.CurrentTime = new AskMeDate();
<<<<<<< HEAD
            Question question = new Question(questionText, AskMeDate.CurrentTime);
            Assert.AreEqual(AskMeDate.CurrentTime, question.AskedOn);
=======
            Question question = new Question(questionText);
            Assert.AreEqual(AskMeDate.CurrentTime.Value, question.QuestionAskedOn.Value);
>>>>>>> question
        }
        [Test]
        public void ShouldCreateOneQuestionInDb()
        {
            string questionText = "What is the use of 'var' key word?";
            AskMeDate.CurrentTime = new AskMeDate();
            Question myFirstQuestion = new Question(questionText);
            session.Save(myFirstQuestion);
            IQuery query = session.CreateQuery("from Question");
            IList<Question> questions = query.List<Question>();
            Assert.AreEqual(1, questions.Count);
        }

    }
}
