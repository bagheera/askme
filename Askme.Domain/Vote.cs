using System;

namespace Askme.Domain
{
    public abstract class  Vote
    {
        private readonly User _user;

        public Vote(User user){
            _user = user;
        }

        protected Vote(){
            throw new NotImplementedException();
        }

        public User User{
            get { return _user;}
        }

        public abstract int Value{ get; }
        
    }
}