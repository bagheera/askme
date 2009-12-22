namespace Askme.Domain
{
    public class AnswerMother{
        public static Answer KamalsGoodAnswer
        {
            get { return new Answer(new AskMeDate(), UserMother.Kamal, "this is good answer"); }
        }

        public static Answer KamalsBadAnswer()
        {
            return new Answer(new AskMeDate(), UserMother.Kamal, "this is bad answer");
        }
    }
}