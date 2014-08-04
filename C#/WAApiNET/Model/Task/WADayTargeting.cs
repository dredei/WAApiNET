namespace WAApiNET.Model.Task
{
    public class WADayTargeting
    {
        public int? Min { get; set; }
        public int? Max { get; set; }
        public int? Hour { get; set; }

        public WADayTargeting()
        {
            this.Min = null;
            this.Max = null;
            this.Hour = null;
        }

        public WADayTargeting( int? min, int? max, int? hour )
        {
            this.Min = min;
            this.Max = max;
            this.Hour = hour;
        }
    }
}