namespace Askme.Domain
{
    public abstract class Vote
    {
        protected const int NegativeValue = -1;
        protected const int PositiveValue = 1;
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

        public virtual void AddPoint(User pointableUser)
        {
            if (value == NegativeValue)
                pointableUser.AddPoint(-1);
            else if (value == PositiveValue)
                pointableUser.AddPoint(10);
        }
    }
}
