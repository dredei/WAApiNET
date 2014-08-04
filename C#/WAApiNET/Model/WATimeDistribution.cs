namespace WAApiNET.Model
{
    public class WATimeDistribution
    {
        public int? Percent { get; set; }
        public int? Priority { get; set; }

        public WATimeDistribution()
        {
            this.Percent = null;
            this.Priority = null;
        }

        public WATimeDistribution( int percent, int priority )
        {
            this.Percent = percent;
            this.Priority = priority;
        }
    }
}