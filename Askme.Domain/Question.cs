namespace Askme.Domain
{
    public class Question
    {
        private readonly AskMeDate askedOn;

        public Question(string text, AskMeDate time)
        {
            Text = text;
            askedOn = time;
        }

        public string Text { get; private set; }

        public AskMeDate AskedOn
        {
            get { return askedOn; }
        }
    }
}