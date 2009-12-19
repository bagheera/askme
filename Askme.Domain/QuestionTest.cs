using System;
using NUnit.Framework;

namespace Askme.Domain
{
    [TestFixture]
    public class QuestionTest
    {
        [Test]
        public void ShouldBeAbleToGetTheQuestionText()
        {
            string questionText = "What is the use of 'var' key word?";
            Question question = new Question(questionText, AskMeDate.CurrentTime);
            Assert.AreEqual(questionText,question.Text);
        }
        [Test]
        public void AskedOnDateShouldDefaultToCurrentDateTime()
        {
            string questionText = "What is the use of 'var' key word?";
            AskMeDate.CurrentTime = new AskMeDate();
            Question question = new Question(questionText, AskMeDate.CurrentTime);
            Assert.AreEqual(AskMeDate.CurrentTime, question.AskedOn);
        }
    }
}
