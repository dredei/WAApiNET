namespace WAApiNET.Model
{
    public class TimeDistribution
    {
        public int? Percent { get; set; }
        public int? Priority { get; set; }

        public TimeDistribution()
        {
            this.Percent = null;
            this.Priority = null;
        }

        public TimeDistribution( int percent, int priority )
        {
            this.Percent = percent;
            this.Priority = priority;
        }
    }
}