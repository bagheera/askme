namespace Askme.Domain
{
    public class AnswerMother{
        
        public static Answer KamalsGoodAnswer
        {
            get { return new Answer(new AskMeDate(), UserMother.Kamal, "this is good answer"); }
        }

        public static Answer KamalsBadAnswer
        {
            get { return new Answer(new AskMeDate(), UserMother.Kamal, "this is bad answer"); }
        }

        public static Answers KamalsAnswers()
        {
            Answers answers = new Answers();
            answers.AddAnswer(KamalsGoodAnswer);
            answers.AddAnswer(KamalsBadAnswer);
            return answers;
        }
    }
}