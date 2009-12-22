using System.Collections.Generic;

namespace Askme.Domain
{
    public class Answers
    {
        private readonly IList<Answer> answers = new List<Answer>();

        public void AddAnswer(Answer answer)
        {
            answers.Add(answer);
        }

        public int Count
        {
            get { return answers.Count; }
        }
    }
}