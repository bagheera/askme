using System;
using System.Collections.Generic;

namespace Askme.Domain
{
    public class Tag
    {
        private int tagId;
        private string tagName;
        private IList<Question> questions;

        public Tag()
        {
        }

        public Tag(string tagName)
        {
            this.tagName = tagName;
        }

        public virtual string TagName
        {
            get { return tagName; }
        }

        public virtual int TagId
        {
            get { return tagId; }
        }

        public virtual IList<Question> Questions
        {
            get { return questions; }
        }
    }
}