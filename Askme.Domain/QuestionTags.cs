using System;
using System.Collections;
using System.Collections.Generic;

namespace Askme.Domain
{
    public class QuestionTags
    {
        private List<Tag> tags;

        public QuestionTags()
        {
            tags = new List<Tag>();
        }

        public void Add(Tag item)
        {
            Tags.Add(item);
        }

        public IList<Tag> Tags
        {
            get { return tags; }
        }

        public bool Equals(QuestionTags other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Tags, Tags);
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
            return (Tags != null ? Tags.GetHashCode() : 0);
        }
    }
}