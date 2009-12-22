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
            Answer answer = new Answer(time, null, "");
            Assert.AreEqual(time, answer.CreatedOn);
        }

        [Test]
        public void AnswerKnowsTheUserWhoAnswered()
        {
            const string userName = "PakodaSingh";
            User user = new User(userName, "******", "diptanu@thoughtworks.com");
            Answer answer = new Answer(AskMeDate.DefaultTime, user, "");
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
            Answer answer = new Answer(AskMeDate.DefaultTime, user, "");
            repository.SaveAnswer(answer);
            repository.Dispose();
        }


        [Test]
        public void AnswerShouldHaveText()
        {
            const string answerText = "This was supposed to be a funny answer but Chandra couldn't come up with one";
            Answer answer = new Answer(AskMeDate.DefaultTime, null, answerText);
            Assert.AreSame(answerText, answer.ToString());
        }

        [Test]
        public void IfUserAndDateAndTextAreSameThenAnswersAreEqual()
        {
            Answer answer1 = new Answer(AskMeDate.DefaultTime, UserMother.Kamal, "this is good answer");
            Answer answer2 = new Answer(AskMeDate.DefaultTime, UserMother.Kamal, "this is good answer");
            Assert.AreEqual(answer1, answer2);
        }
    }
}