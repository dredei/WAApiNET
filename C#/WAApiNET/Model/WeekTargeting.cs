namespace WAApiNET.Model
{
    public class WeekTargeting
    {
        public int? Day { get; set; }
        public double? Target { get; set; }

        public WeekTargeting()
        {
            this.Day = null;
            this.Target = null;
        }

        public WeekTargeting( int? day, double? target )
        {
            this.Day = day;
            this.Target = target;
        }
    }
}