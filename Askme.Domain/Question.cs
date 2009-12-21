namespace Askme.Domain
{
    public class Question
    {
        private readonly AskMeDate askedOn;

        private int Id;
        private string text;

        public Question()
        {
        }

        public Question(string text)
        {
            this.text = text;
            askedOn = new AskMeDate();
        }

        public virtual int QuestionId
        {
            get { return Id; }
        }

        public virtual string QuestionText
        {
            get { return text; }
        }

        public virtual AskMeDate QuestionAskedOn
        {
            get { return askedOn; }
        }
       
    }
}