namespace Askme.Domain
{
    public abstract class Vote
    {
        protected Vote()
        {
        }

        protected Vote(User user, int value)
        {
            this.user = user;
            this.value = value;
        }

        protected User user;
        private readonly int voteId;
        protected int value;

        public virtual int VoteId
        {
            get { return voteId; }
        }

        public virtual User User
        {
            get { return user; }
        }

        public virtual int Value
        {
            get { return value; }
        }
    }
}
