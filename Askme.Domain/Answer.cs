using System;

namespace Askme.Domain
{
    public class Answer
    {
        private readonly AskMeDate createdOn;
        private readonly User user;
        private readonly string text;
        private int answerId;
        private Votes votes = new Votes();
        
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
        }

        public virtual User User
        {
            get { return user; }
        }

        public virtual AskMeDate CreatedOn
        {
            get { return createdOn; }
        }

        public virtual Votes Votes
        {
            get { return votes; }
        }

        public override string ToString()
        {
            return text;
        }

        public virtual bool Equals(Answer other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.createdOn, createdOn) && Equals(other.user, user) && Equals(other.text, text);
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
                return result;
            }
        }

        public virtual void CastVote(Vote vote){
            votes.Add(vote);                  
        }
    }
}