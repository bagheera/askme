using System;

namespace Askme.Domain
{
    public class AskMeDate
    {
        private readonly DateTime value;

        public AskMeDate(DateTime dateTime)
        {
            this.value = dateTime;
        }

        public DateTime Value
        {
            get { return value; }
        }
    }
}