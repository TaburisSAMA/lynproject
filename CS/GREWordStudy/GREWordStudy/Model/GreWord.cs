namespace GREWordStudy.Model
{
    partial class GreWord
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
        public int Tried { get { return Forgotten + Remembered; } }
    }
}


