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
            Question question = new Question(questionText);
            Assert.AreEqual(questionText,question.Text);
        }
        [Test]
        public void ASkedOnDateShouldDefaultToCurrentDateTime()
        {
            string questionText = "What is the use of 'var' key word?";
            AskMeDate.Now = DateTime.Now;
            Question question = new Question(questionText);
            Assert.AreEqual(AskMeDate.Now, question.AskedOn.Value);
        }
    }
}
