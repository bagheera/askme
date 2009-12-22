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
            User user = new User("shanu","shanu","shanu@shanu.com");
            Question question = new Question(questionText,user);
            Assert.AreEqual(questionText,question.QuestionText);
        }
        
        [Test]
        public void ShouldBeAbleToGetTheQuestionTag()
        {
            string questionText = "What is the use of 'var' key word?";
            List<string> tags = new List<string>();
            tags.Add("abc");
            tags.Add("def");
            User user = new User("shanu", "shanu", "shanu@shanu.com");
            Question question = new Question(questionText,user, tags);
            Assert.AreEqual(new QuestionTags(tags),question.Tags);
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
    }
}
