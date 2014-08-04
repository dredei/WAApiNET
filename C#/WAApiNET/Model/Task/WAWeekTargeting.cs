namespace WAApiNET.Model.Task
{
    public class WAWeekTargeting
    {
        public int? Day { get; set; }
        public double? Target { get; set; }

        public WAWeekTargeting()
        {
            this.Day = null;
            this.Target = null;
        }

        public WAWeekTargeting( int? day, double? target )
        {
            this.Day = day;
            this.Target = target;
        }
    }
}