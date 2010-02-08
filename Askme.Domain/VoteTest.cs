using System;
using System.Collections.Generic;
using NUnit.Framework;
namespace Askme.Domain
{
    [TestFixture]
    public class VoteTest
    {
        [Test]
        public void VoteShouldContainUserInfo(){
            User user = new User("user1", "123", "a@b.com");
            AnswerVote vote = AnswerVote.PositiveVote(user);

            Assert.AreEqual(vote.User.Username, user.Username);
        }


        [Test]
        public void ShouldBeAbleToVoteAnAnswer(){
            User user = new User("user1", "123", "a@b.com");
            AnswerVote vote = AnswerVote.PositiveVote(user);

            User userWhoAnswered = new User("Answerer", "123", "b@c.com");
            Answer answer = new Answer(new AskMeDate(), userWhoAnswered, "Dummy answer" );
            answer.CastVote(vote);
        }

        [Test]
        public void AnswererShouldGetTenPointsOnReceivingPositiveVote()
        {
            User user = new User("user1", "123", "a@b.com");
            AnswerVote vote = AnswerVote.PositiveVote(user);

            User userWhoAnswered = new User("Answerer", "123", "b@c.com");
            Answer answer = new Answer(new AskMeDate(), userWhoAnswered, "Dummy answer" );
            answer.CastVote(vote);
            Assert.AreEqual(10, userWhoAnswered.Points());
        }

        [Test]
        public void AnswererShouldGetMinusOnePointOnReceivingNegativeVote()
        {
            User user = new User("user1", "123", "a@b.com");
            AnswerVote vote = AnswerVote.NegativeVote(user);

            User userWhoAnswered = new User("Answerer", "123", "b@c.com");
            Answer answer = new Answer(new AskMeDate(), userWhoAnswered, "Dummy answer" );
            answer.CastVote(vote);
            Assert.AreEqual(-1, userWhoAnswered.Points());
        }

        [Test]
        public void AnswerShouldReturnNumberOfVotes()
        {
            User user = new User("user1", "123", "a@b.com");
            AnswerVote vote = AnswerVote.PositiveVote(user);

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
            AnswerVote vote = AnswerVote.PositiveVote(user);

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
            AnswerVote vote = AnswerVote.NegativeVote(user);

            answer.CastVote(vote);
        }


        
        [Test]
        public void PositiveVotesShouldReturnPositiveValue()
        {
            User user = new User("user1", "123", "a@b.com");
            Vote vote = AnswerVote.PositiveVote(user);

            Assert.AreEqual(1, vote.Value);
        }

        [Test]
        public void NegativeVotesShouldReturnNegativeValue()
        {
            User user = new User("user1", "123", "a@b.com");
            Vote vote = AnswerVote.NegativeVote(user);

            Assert.AreEqual(-1, vote.Value);
        }


        [Test]
        public void ShouldBeAbleToSaveAndRetrieveVotesInAnswer()
        {
            User user = UserMother.Kamal;

            Answer answer = new Answer(new AskMeDate(), user, "answer to be voted");
            Repository repository = Repository.GetInstance();
            repository.SaveUser(user);


            AnswerVote vote = AnswerVote.NegativeVote(user);
            answer.CastVote(vote);
            repository.SaveAnswer(answer);

            repository.Evict(answer);

            string searchString = "answer to be voted";
            IList<Answer> answersFound = repository.SearchKeyWordInAnswers(searchString);

            Assert.AreEqual(1, answersFound.Count);
            Assert.AreEqual(1, answersFound[0].Votes.Count);

        }
    }
}
