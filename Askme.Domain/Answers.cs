using System;
using System.Collections.Generic;

namespace Askme.Domain
{
    public class Answers
    {
        private readonly IList<Answer> answers = new List<Answer>();

        public Answers(){}

        public Answers(IList<Answer> answers)
        {
            foreach (Answer answer in answers)
            {
                this.answers.Add(answer);
            }
        }

        public void AddAnswer(Answer answer)
        {
            answers.Add(answer);
        }

        public int Count
        {
            get { return answers.Count; }
        }

        public virtual bool Equals(Answers other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.answers, answers);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Answers)) return false;
            return Equals((Answers) obj);
        }

        public override int GetHashCode()
        {
            return (answers != null ? answers.GetHashCode() : 0);
        }

        public Answer getAcceptedAnswer()
        {
            foreach (Answer answer in answers)
            {
                if(answer.IsAccepted())
                {
                    return answer;
                }
            }
            return null;
        }

        public bool	CanBeAccepted(Answer answer)
        {
            answers.Contains(answer)
        }
    }
}