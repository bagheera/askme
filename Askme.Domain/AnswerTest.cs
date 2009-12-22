using System;
using NUnit.Framework;

namespace Askme.Domain
{
    [TestFixture]
    public class AnswerTest
    {
        [SetUp]
        public void Setup()
        {
            AskMeDate.DefaultTime = new AskMeDate(DateTime.Now);
        }
        [Test]
        public void AnswerKnowsWhenItWasCreated()
        {
            AskMeDate time = AskMeDate.DefaultTime;
            Answer answer = new Answer(time, null);
            Assert.AreEqual(time, answer.CreatedOn);
        }

        [Test]
        public void AnswerKnowsTheUserWhoAnswered()
        {
            const string userName = "PakodaSingh";
            User user = new User(userName, "******", "diptanu@thoughtworks.com");
            Answer answer = new Answer(AskMeDate.DefaultTime,user);
            Assert.AreEqual(user, answer.User);
        }

        [Test]
        public void VerifyAnswerInsertion()
        {
            Repository repository = Repository.GetInstance();
            User user = new User("PakodaSingh", "******", "diptanu@thoughtworks.com");
            user.UserId = "1";
            Console.WriteLine(user.UserId);
            repository.SaveUser(user);
            Console.WriteLine(user.UserId);
            Answer answer = new Answer(AskMeDate.DefaultTime, user);
            repository.SaveAnswer(answer);
            repository.Dispose();
        }
    }
}