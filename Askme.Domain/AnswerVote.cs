namespace Askme.Domain
{
    public class AnswerVote:Vote
    {
        private Answer _answer;

        protected AnswerVote(){}
        private AnswerVote(User user, int value) : base(user, value)
        {
        }

        public static AnswerVote PositiveVote(User user)
        {
            var vote = new AnswerVote(user, 1);
            return vote;
        }

        public static AnswerVote NegativeVote(User user)
        {
            var vote = new AnswerVote(user, -1);
            return vote;
        }
   }
}