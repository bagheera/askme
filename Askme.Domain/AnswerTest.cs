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
            Answer answer = new Answer(time);
            Assert.AreEqual(time, answer.CreatedOn);
        }
    }
}