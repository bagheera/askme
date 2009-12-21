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
            Question question = new Question(questionText, AskMeDate.DefaultTime);
            Assert.AreEqual(questionText,question.Text);
        }
        [Test]
        public void AskedOnDateShouldDefaultToCurrentDateTime()
        {
            string questionText = "What is the use of 'var' key word?";
            AskMeDate.DefaultTime = new AskMeDate(new DateTime(2010, 1, 1));
            Question question = new Question(questionText, new AskMeDate());
            Assert.AreEqual(AskMeDate.DefaultTime, question.AskedOn);
        }
    }
}
