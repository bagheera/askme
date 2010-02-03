using System;

namespace Askme.Domain
{
    public class Answer
    {
        private readonly AskMeDate createdOn;
        private readonly User user;
        private readonly string text;
        private int answerId;
        private int accepted;
        private object localLock = new object();

        public virtual int AnswerId
        {
            get { return answerId; }
        }

        protected Answer()
        {
        }

        public Answer(AskMeDate createdOn, User user, string text)
        {
            this.createdOn = createdOn;
            this.user = user;
            this.text = text;
            accepted = 0;
        }

        public virtual User User
        {
            get { return user; }
        }

        public virtual AskMeDate CreatedOn
        {
            get { return createdOn; }
        }

        public virtual int Accepted
        {
            get { return accepted; }
        }
        public override string ToString()
        {
            return text;
        }

        public virtual bool Equals(Answer other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.createdOn, createdOn) && Equals(other.user, user) && Equals(other.text, text) && other.answerId == answerId && other.accepted == accepted;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Answer)) return false;
            return Equals((Answer) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = (createdOn != null ? createdOn.GetHashCode() : 0);
                result = (result*397) ^ (user != null ? user.GetHashCode() : 0);
                result = (result*397) ^ (text != null ? text.GetHashCode() : 0);
                result = (result*397) ^ answerId;
                result = (result*397) ^ accepted;
                return result;
            }
        }

        public virtual void Accept(){
            lock (localLock)
            {
                if (accepted == 0)
                {
                    accepted = 1;
                }
                else
                {
                    throw new NotSupportedException("An answer cannot be accepted more than once");
                }
            }
        }

        public virtual bool IsAccepted()
        {
            return accepted == 0 ? false : true;
        }
    }
}