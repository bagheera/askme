using System;
using System.Collections.Generic;
using System.IO;
using NHibernate;
using NUnit.Framework;

namespace Askme.Domain
{
    [TestFixture]
    public class QuestionTest:NHibernateInMemoryBase
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
            Question question = new Question(questionText);
            Assert.AreEqual(questionText,question.QuestionText);
        }
        
        [Test]
        public void ShouldBeAbleToGetTheQuestionTag()
        {
            string questionText = "What is the use of 'var' key word?";
            List<string> tags = new List<string>();
            tags.Add("abc");
            tags.Add("def");
            Question question = new Question(questionText, tags);
            Assert.AreEqual(new QuestionTags(tags),question.Tags);
        }
        [Test]
        public void AskedOnDateShouldDefaultToCurrentDateTime()
        {
            string questionText = "What is the use of 'var' key word?";
   
            AskMeDate.DefaultTime = new AskMeDate(DateTime.Now);

            Question question = new Question(questionText);
            Assert.AreEqual(AskMeDate.DefaultTime.Value, question.QuestionAskedOn.Value);
        }
        [Test]
        public void ShouldCreateOneQuestionInDb()
        {
            string questionText = "What is the use of 'var' key word?";
            AskMeDate.DefaultTime = new AskMeDate(DateTime.Now);
            Question myFirstQuestion = new Question(questionText);
            session.Save(myFirstQuestion);
            IQuery query = session.CreateQuery("from Question");
            IList<Question> questions = query.List<Question>();
            Assert.AreEqual(1, questions.Count);
        }

        [Test]
        public void ShouldCollectAnswers()
        {
            AskMeDate.DefaultTime = new AskMeDate(DateTime.Now);
            Question question = new Question("What is the use of 'var' key word?");
            question.AddAnswer(new Answer(AskMeDate.DefaultTime, null, ""));
            Assert.AreEqual(1, question.NumberOfAnswers);

        }
    }
}
