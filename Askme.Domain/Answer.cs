using System;

namespace Askme.Domain
{
    public class Answer
    {
        private readonly AskMeDate createdOn;
        private readonly User user;

        public Answer(AskMeDate createdOn, User user)
        {
            this.createdOn = createdOn;
            this.user = user;
        }

        public User User
        {
            get { return user; }
        }

        public AskMeDate CreatedOn
        {
            get { return createdOn; }
        }
    }
}