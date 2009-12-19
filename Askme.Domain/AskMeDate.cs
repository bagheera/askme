using System;

namespace Askme.Domain
{
    public class AskMeDate
    {
        private readonly DateTime askmeDate;
        private static AskMeDate currentTime;

        public AskMeDate()
        {
            askmeDate = DateTime.Now;
        }

        public AskMeDate(DateTime dateTime)
        {
            askmeDate = dateTime;
        }

        public DateTime Value
        {
            get { return askmeDate; }
        }

        public static AskMeDate CurrentTime
        {
            get { return currentTime; }
            set { currentTime = new AskMeDate(value.Value); }
        }
    }
}