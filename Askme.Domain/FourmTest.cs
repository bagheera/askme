using NUnit.Framework;

namespace Askme.Domain
{
    [TestFixture]
    public class ForumTest
    {
        [Test]
        public void AddQuestion()
        {
            Forum fourm = new Forum();
            fourm.AddQuestion(new Question("Whats my name?", new User("Newyork", "Password", "abc@yahoo.com")));
            Assert.AreEqual(1, fourm.Count);
        }
        [Test]
        public void VerifyIfForumCanTellIfItHasASpecificQuestion()
        {
            Forum fourm = new Forum();
            Question question1 = new Question("Whats my first name?", new User("Newyork", "Password", "abc@yahoo.com"));
            Question question2 = new Question("Whats my last name?", new User("Newyork", "Password", "abc@yahoo.com"));
            fourm.AddQuestion(question1);
            Assert.AreEqual(true, fourm.HasQuestion(question1));
            Assert.AreEqual(false, fourm.HasQuestion(question2));
        }
    }
}