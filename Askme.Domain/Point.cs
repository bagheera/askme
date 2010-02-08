namespace Askme.Domain
{
    public class Point
    {
        private int value;
        public Point()
        {
            value = 0;
        }

        public int Value
        {
            get { return value; }
        }

        public void AddPoint(int value)
        {
            this.value += value;
        }
    }
}