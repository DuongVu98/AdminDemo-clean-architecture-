namespace AdminDemo.Adapters.Models
{
    public class Count
    {
        private int thiscount;

        public Count(int thiscount)
        {
            this.thiscount = thiscount;
        }

        public Count()
        {
        }

        public int Thiscount
        {
            get => thiscount;
            set => thiscount = value;
        }
    }
}