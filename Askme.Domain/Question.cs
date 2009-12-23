using System.Collections.Generic;

namespace Askme.Domain
{
    public class Question
    {
        private readonly AskMeDate askedOn;
        private User user;

        private int Id;
        private string text;
        private QuestionTags tags = new QuestionTags();
        private Answers answers = new Answers();

        public Question()
        {
        }

        public Question(string text, User user)
        {
            this.text = text;
            this.user = user;
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
            get { return tags; }
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

        public virtual void AddTags(Tag tag)
        {
            tags.Add(tag);
        }
    }
}