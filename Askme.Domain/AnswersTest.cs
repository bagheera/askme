using NUnit.Framework;

namespace Askme.Domain
{
    [TestFixture]
    public class AnswersTest
    {
        [Test]
        public void AddAnswer()
        {
            Answers answers = new Answers();
            answers.AddAnswer(AnswerMother.KamalsGoodAnswer(UserMother.Kamal));
            Assert.AreEqual(1, answers.Count);
            answers.AddAnswer(AnswerMother.KamalsBadAnswer(UserMother.Kamal));
            Assert.AreEqual(2, answers.Count);
        }
    }
}