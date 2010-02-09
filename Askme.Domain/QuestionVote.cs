using System;

namespace Askme.Domain
{
    public class QuestionVote:Vote
    {

        private Question _question;

        public virtual Question Question
        {
            get { return _question; }
            set { _question = value; }
        }

        protected QuestionVote(){}
        private QuestionVote(User user, int value) : base(user, value)
        {
        }

        public static QuestionVote PositiveVote(User user)
        {
            var vote = new QuestionVote(user, PositiveValue);
            return vote;
        }

        public static QuestionVote NegativeVote(User user)
        {
            var vote = new QuestionVote(user, NegativeValue);
            return vote;
        }
    }
}