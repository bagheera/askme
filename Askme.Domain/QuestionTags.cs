using System.Collections;
using System.Collections.Generic;

namespace Askme.Domain
{
    public class QuestionTags
    {
        private List<string> tags;

        public QuestionTags(List<string> tags)
        {
            this.tags = tags;
        }
        public int Add(object value)
        {
            return ((IList) tags).Add(value);
        }

        public void Add(string item)
        {
            tags.Add(item);
        }

        public bool Equals(QuestionTags other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.tags, tags);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (QuestionTags)) return false;
            return Equals((QuestionTags) obj);
        }

        public override int GetHashCode()
        {
            return (tags != null ? tags.GetHashCode() : 0);
        }
    }
}