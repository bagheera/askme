using System;

namespace Askme.Domain
{
    public class Tag
    {
        private string tagName;
        private int tagId;

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
    }
}