using System;

namespace Askme.Domain
{
    public class PositiveVote : Vote
    {
        public PositiveVote(User user):base(user, 1){
        }
    }
}