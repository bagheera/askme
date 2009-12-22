using System;
using System.Collections.Generic;
using NUnit.Framework.Constraints;

namespace Askme.Domain
{
    public class Question
    {
        private readonly AskMeDate askedOn;

        private int Id;
        private string text;
        private QuestionTags questionTags;

        public Question()
        {
        }

        public Question(string text)
        {
            this.text = text;
            askedOn = new AskMeDate();
        }

        public Question(string text, List<string>tags)
        {
            this.text = text;
            this.questionTags = new QuestionTags(tags);
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
            get { return questionTags;  }
        }

        public virtual AskMeDate QuestionAskedOn
        {
            get { return askedOn; }
        }

        public virtual int NumberOfAnswers
        {
            get { return 1; }
        }

        public virtual void AddAnswer(Answer answer)
        {
            
        }
    }
}