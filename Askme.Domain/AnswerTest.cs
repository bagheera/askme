using NUnit.Framework;

namespace Askme.Domain
{
    [TestFixture]
    public class AnswerTest
    {
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
    }
}