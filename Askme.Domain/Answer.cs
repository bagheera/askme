using System;

namespace Askme.Domain
{
    public class Answer
    {
        private readonly AskMeDate createdOn;
        private readonly User user;
        private readonly string text;
        private int answerId;

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

        public override string ToString()
        {
            return text;
        }
    }
}