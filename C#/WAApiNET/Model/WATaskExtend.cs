#region Using

using System.Collections.Generic;
using Newtonsoft.Json;

#endregion

namespace WAApiNET.Model
{
    public class WATaskExtend : WATask
    {
        [JsonProperty( PropertyName = "Geo targeting" )]
        public List<GeoTargeting> GeoTargeting { get; set; }

        [JsonProperty( PropertyName = "Day targeting" )]
        public List<DayTargeting> DayTargeting { get; set; }

        [JsonProperty( PropertyName = "Day stats" )]
        public List<DayTargetingExtend> DayStats { get; set; }

        [JsonProperty( PropertyName = "Week targeting" )]
        public List<WeekTargeting> WeekTargeting { get; set; }

        [JsonProperty( PropertyName = "Time distribution" )]
        public List<TimeDistribution> TimeDistribution { get; set; }

        public WATaskExtend()
        {
            this.GeoTargeting = null;
            this.DayTargeting = null;
            this.DayStats = null;
            this.WeekTargeting = null;
            this.TimeDistribution = null;
        }

        public WATaskExtend( int? taskId, int? listId, int? afterClick, bool allowProxy, bool ignoreGu, double? growth,
            string domain, string profile, bool frozen, bool listMode, int? rangeSize, int? uniquePeriod, string name,
            string mask, int? days, string extSource, int? beforeClick, string profileSorage,
            List<GeoTargeting> geoTargeting, List<DayTargeting> dayTargeting, List<DayTargetingExtend> dayStats,
            List<WeekTargeting> weekTargeting, List<TimeDistribution> timeDistribution )
            : base( taskId, listId, afterClick, allowProxy, ignoreGu, growth, domain, profile, frozen, listMode,
                rangeSize, uniquePeriod, name, mask, days, extSource, beforeClick, profileSorage )
        {
            this.GeoTargeting = geoTargeting;
            this.DayTargeting = dayTargeting;
            this.DayStats = dayStats;
            this.WeekTargeting = weekTargeting;
            this.TimeDistribution = timeDistribution;
        }

        public WATaskExtend( WATask task, List<GeoTargeting> geoTargeting, List<DayTargeting> dayTargeting,
            List<DayTargetingExtend> dayStats, List<WeekTargeting> weekTargeting,
            List<TimeDistribution> timeDistribution )
            : base( task )
        {
            this.GeoTargeting = geoTargeting;
            this.DayTargeting = dayTargeting;
            this.DayStats = dayStats;
            this.WeekTargeting = weekTargeting;
            this.TimeDistribution = timeDistribution;
        }
    }
}