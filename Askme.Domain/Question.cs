using System.Collections;
using System.Collections.Generic;

namespace Askme.Domain
{
    public class Question
    {
        private readonly AskMeDate askedOn;
        private User user;

        private int id;
        private string text;
        private IList<Tag> tags = new List<Tag>();
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
            get { return id; }
        }

        public virtual string QuestionText
        {
            get { return text; }
        }

        public virtual IList<Tag> Tags
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

        public virtual bool Equals(Question other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.askedOn, askedOn) && Equals(other.user, user) && Equals(other.text, text) && Equals(other.tags, tags) && Equals(other.answers, answers);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Question)) return false;
            return Equals((Question) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = (askedOn != null ? askedOn.GetHashCode() : 0);
                result = (result*397) ^ (user != null ? user.GetHashCode() : 0);
                result = (result*397) ^ (text != null ? text.GetHashCode() : 0);
                result = (result*397) ^ (tags != null ? tags.GetHashCode() : 0);
                result = (result*397) ^ (answers != null ? answers.GetHashCode() : 0);
                return result;
            }
        }
    }
}