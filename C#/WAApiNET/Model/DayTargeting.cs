namespace WAApiNET.Model
{
    public class DayTargeting
    {
        public int? Min { get; set; }
        public int? Max { get; set; }
        public int? Hour { get; set; }

        public DayTargeting()
        {
            this.Min = null;
            this.Max = null;
            this.Hour = null;
        }

        public DayTargeting( int? min, int? max, int? hour )
        {
            this.Min = min;
            this.Max = max;
            this.Hour = hour;
        }
    }
}