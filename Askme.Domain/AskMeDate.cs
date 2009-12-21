using System;

namespace Askme.Domain
{
    public class AskMeDate
    {
        private readonly DateTime askmeDate;
        private static AskMeDate defaultTime;

        public AskMeDate()
        {
            if (defaultTime == null) throw new ArgumentNullException();
            this.askmeDate = defaultTime.Value;
        }

        public AskMeDate(DateTime dateTime)
        {
            askmeDate = dateTime;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(AskMeDate)) return false;
            AskMeDate cObj = obj as AskMeDate;
            if (cObj == null) return false;
            return (cObj.Value.CompareTo(askmeDate) == 0);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public DateTime Value
        {
            get { return askmeDate; }
        }

        public static AskMeDate DefaultTime
        {
            get { return defaultTime; }
            set { defaultTime = new AskMeDate(value.Value); }
        }
    }
}