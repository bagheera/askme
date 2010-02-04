using System.Collections.Generic;

namespace Askme.Domain
{
    public class Forum
    {
        private readonly IList<Question> questions = new List<Question>();

        public Forum(){}

        public Forum(IList<Question> questions)
        {
            foreach (Question question in questions)
            {
                this.questions.Add(question);
            }
        }

        public void AddQuestion(Question question)
        {
            questions.Add(question);
        }

        public int Count
        {
            get { return questions.Count; }
        }

        public bool HasQuestion(Question question)
        {
            foreach (Question myQuestion in questions)
            {
                if (question.Equals(myQuestion)) {
                    return true;
                }
            }
            return false;
        }

        public bool Equals(Forum other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.questions, questions);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Forum)) return false;
            return Equals((Forum) obj);
        }

        public override int GetHashCode()
        {
            return (questions != null ? questions.GetHashCode() : 0);
        }
    }
}
