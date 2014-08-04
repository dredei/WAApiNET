namespace WAApiNET.Model.Task
{
    public class WADayTargetingExtend : WADayTargeting
    {
        public int? Recd { get; set; }
        public int? Incomplete { get; set; }
        public int? Overload { get; set; }

        public WADayTargetingExtend()
        {
            this.Recd = null;
            this.Incomplete = null;
            this.Overload = null;
        }

        public WADayTargetingExtend( int? min, int? max, int? hour, int? recd, int? incomplete, int? overload )
            : base( min, max, hour )
        {
            this.Recd = recd;
            this.Incomplete = incomplete;
            this.Overload = overload;
        }
    }
}