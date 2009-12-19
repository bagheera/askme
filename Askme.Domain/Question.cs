namespace Askme.Domain
{
    public class Question
    {
        private AskMeDate askedOn;

        public Question(string text)
        {
            Text = text;
            askedOn = new AskMeDate();
        }

        public string Text
        {
            get; private set;
        }

        public AskMeDate AskedOn
        {
            get { return askedOn; }
        }
    }
}