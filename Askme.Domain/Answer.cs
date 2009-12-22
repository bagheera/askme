using System;

namespace Askme.Domain
{
    public class Answer
    {
        private readonly AskMeDate createdOn;
        private readonly User user;
        private int answerId;

        protected Answer()
        {
        }

        public Answer(AskMeDate createdOn, User user)
        {
            this.createdOn = createdOn;
            this.user = user;
        }

        public virtual User User
        {
            get { return user; }
        }

        public virtual AskMeDate CreatedOn
        {
            get { return createdOn; }
        }
    }
}