using System;

namespace Askme.Domain
{
    public class Answer
    {
        private readonly AskMeDate createdOn;

        public Answer(AskMeDate createdOn)
        {
            this.createdOn = createdOn;
        }

        public AskMeDate CreatedOn
        {
            get { return createdOn; }
        }
    }
}