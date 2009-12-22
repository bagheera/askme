using System.Collections.Generic;

namespace Askme.Domain
{
    public class Question
    {
        private readonly AskMeDate askedOn;

        private int Id;
        private string text;
        private QuestionTags questionTags;
        private Answers answers = new Answers();

        public Question()
        {
        }

        public Question(string text)
        {
            this.text = text;
            askedOn = new AskMeDate();
        }

        public Question(string text, List<string> tags)
        {
            this.text = text;
            questionTags = new QuestionTags(tags);
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

        public virtual QuestionTags Tags
        {
            get { return questionTags; }
        }

        public virtual AskMeDate QuestionAskedOn
        {
            get { return askedOn; }
        }

        public virtual void AddAnswer(Answer answer)
        {
            answers.AddAnswer(answer);
        }

        public virtual int NumberOfAnswers
        {
            get { return answers.Count; }
        }
    }
}