using System;

namespace Askme.Domain
{
    public class NegativeVote : Vote
    {
        public NegativeVote(User user) : base(user){
            
        }

        public override int Value{
            get { return -1; }
        }
    }
}