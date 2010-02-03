using System;
using NUnit.Framework;
namespace Askme.Domain
{
    [TestFixture]
    public class VoteTest
    {
        [Test]
        public void VoteShouldContainUserInfo(){
            User user = new User("user1", "123", "a@b.com");
            Vote vote = new PositiveVote(user);

            Assert.AreEqual(vote.User.Username, user.Username);
        }


        [Test]
        public void ShouldBeAbleToVoteAnAnswer(){
            User user = new User("user1", "123", "a@b.com");
            Vote vote = new PositiveVote(user);

            User userWhoAnswered = new User("Answerer", "123", "b@c.com");
            Answer answer = new Answer(new AskMeDate(), userWhoAnswered, "Dummy answer" );
            answer.CastVote(vote);
        }

        [Test]
        public void AnswerShouldReturnNumberOfVotes()
        {
            User user = new User("user1", "123", "a@b.com");
            Vote vote = new PositiveVote(user);

            User userWhoAnswered = new User("Answerer", "123", "b@c.com");
            Answer answer = new Answer(new AskMeDate(), userWhoAnswered, "Dummy answer");
            answer.CastVote(vote);
            Assert.AreEqual(1, answer.Votes.Count);
        }
              
        
        
        [Test]
        [ExpectedException(typeof(Exception))]
        public void OneUserCanOnlyCastOneVoteForAnAnswer(){
            User userWhoAnswered = new User("Answerer", "123", "b@c.com");
            Answer answer = new Answer(new AskMeDate(), userWhoAnswered, "Dummy answer");
            
            User user = new User("user1", "123", "a@b.com");
            Vote vote = new PositiveVote(user);

            answer.CastVote(vote);
            Assert.IsTrue(answer.Votes.HasUserVoted(user));

            answer.CastVote(vote);  //this should throw an exception
        }


        [Test]
        public void UserShouldBeAbleCastNegativeVote()
        {
            User userWhoAnswered = new User("Answerer", "123", "b@c.com");
            Answer answer = new Answer(new AskMeDate(), userWhoAnswered, "Dummy answer");

            User user = new User("user1", "123", "a@b.com");
            Vote vote = new NegativeVote(user);

            answer.CastVote(vote);
        }


        
        [Test]
        public void PositiveVotesShouldReturnPositiveValue()
        {
            User user = new User("user1", "123", "a@b.com");
            Vote vote = new PositiveVote(user);

            Assert.AreEqual(1, vote.Value);
        }

        [Test]
        public void NegativeVotesShouldReturnNegativeValue()
        {
            User user = new User("user1", "123", "a@b.com");
            Vote vote = new NegativeVote(user);

            Assert.AreEqual(-1, vote.Value);
        }


        [Test]
        public void MultipleUsersShouldBeAbleToVoteAnAnswer()
        {
            User userWhoAnswered = new User("Answerer", "123", "b@c.com");
            Answer answer = new Answer(new AskMeDate(), userWhoAnswered, "Dummy answer");

            User user1 = new User("user1", "123", "a@b.com");
            Vote vote1 = new PositiveVote(user1);
            User user2 = new User("user2", "123", "c@b.com");
            Vote vote2 = new NegativeVote(user2);

            answer.CastVote(vote1);
            answer.CastVote(vote2);

            Assert.AreEqual(2, answer.Votes.Count);
        }






        
    }
}
