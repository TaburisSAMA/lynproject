namespace GREWordStudy.Model
{
    public class PlainWord
    {
        public int RememberPercentile
        {
            get
            {
                if (Remembered + Forgotten == 0)
                    return -1;
                else
                    return (int)(Remembered * 100.0 / (Remembered + Forgotten));
            }
        }

        public double Forgotten { get; set; }

        public double Remembered { get; set; }

        public int Tried { get { return (int)(Forgotten + Remembered); } }
        
        public int Index { get; set; }

        public string Word { get; set; }

        public int Hardness { get; set; }
    }
}
