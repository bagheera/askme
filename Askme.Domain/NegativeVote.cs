using System;

namespace Askme.Domain
{
    public class NegativeVote : Vote
    {
        public NegativeVote(User user) : base(user, -1){
            
        }
    }
}