namespace WAApiNET.Model
{
    public class DayTargetingExtend : DayTargeting
    {
        public int? Recd { get; set; }
        public int? Incomplete { get; set; }
        public int? Overload { get; set; }

        public DayTargetingExtend()
        {
            this.Recd = null;
            this.Incomplete = null;
            this.Overload = null;
        }

        public DayTargetingExtend( int? min, int? max, int? hour, int? recd, int? incomplete, int? overload )
            : base( min, max, hour )
        {
            this.Recd = recd;
            this.Incomplete = incomplete;
            this.Overload = overload;
        }
    }
}