namespace Askme.Domain
{
    public class AnswerMother{
        public static Answer KamalsGoodAnswer(User user)
        {
            return new Answer(new AskMeDate(), user, "this is good answer");
        }

        public static Answer KamalsBadAnswer(User user)
        {
            return new Answer(new AskMeDate(), user, "this is bad answer");
        }

        public static Answers KamalsAnswers()
        {
            Answers answers = new Answers();
            answers.AddAnswer(KamalsGoodAnswer(UserMother.Kamal));
            answers.AddAnswer(KamalsBadAnswer(UserMother.Kamal));
            return answers;
        }
    }
}