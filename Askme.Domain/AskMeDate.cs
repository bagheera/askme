using System;

namespace Askme.Domain
{
    public class AskMeDate
    {
        private readonly DateTime value;
        private static DateTime now;

        public AskMeDate()
        {
            this.value = now;
        }

        public AskMeDate(DateTime dateTime)
        {
            this.value = dateTime;
        }

        public DateTime Value
        {
            get { return value; }
        }

        public static DateTime Now
        {
            get { 
                if (DateTime.MinValue == now)
                    return DateTime.Now; 
                return now;
            }
            set { now = value; }
        }
    }
}