using System;

namespace Askme.Domain
{
    public class  Vote
    {
        private readonly User user;
        private readonly int voteId;
        protected readonly int value;
        
        protected Vote(User user, int value){
            this.user = user;
            this.value = value;
        }
       
        public Vote(){
            
        }

        public virtual int VoteId
        {
            get { return voteId; }
        }

        public virtual User User
        {
            get { return user; }
        }

        public virtual int Value{
            get { return value;}
        }
    }
}