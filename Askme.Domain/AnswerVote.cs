namespace Askme.Domain
{
    public class AnswerVote : Vote
    {
        protected AnswerVote() { }
        private AnswerVote(User user, int value)
            : base(user, value)
        {
        }

        public static AnswerVote PositiveVote(User user)
        {
            var vote = new AnswerVote(user, PositiveValue);
            return vote;
        }

        public static AnswerVote NegativeVote(User user)
        {
            var vote = new AnswerVote(user, NegativeValue);
            return vote;
        }

        
    }
}