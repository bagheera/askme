using System;

namespace Askme.Domain
{
    public class PositiveVote : Vote
    {
        public PositiveVote(User user):base(user){
        }

        public override int Value{
            get { return 1; }
        }
    }
}