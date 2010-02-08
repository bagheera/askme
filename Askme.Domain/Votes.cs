using System;
using System.Collections.Generic;

namespace Askme.Domain
{
    public class Votes
    {
        private readonly IList<Vote> votes = new List<Vote>();


        public int Count{
            get { return votes.Count; }
        }
        

        public void Add(Vote vote){
            if(HasUserVoted(vote.User))
                throw new Exception("User has already voted");
            votes.Add(vote);
        }

        public bool HasUserVoted(User user){
            int count = ((List<Vote>)votes).FindAll(e => e.User.Equals(user)).Count;
            return count == 1;
        }
    }
}
