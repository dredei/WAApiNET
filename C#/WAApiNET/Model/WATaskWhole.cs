#region Using

using System.Collections.Generic;
using Newtonsoft.Json;

#endregion

namespace WAApiNET.Model
{
    public class WATaskWhole : WATask
    {
        [JsonProperty( PropertyName = "Geo targeting" )]
        public List<WAGeoTargeting> GeoTargeting { get; set; }

        [JsonProperty( PropertyName = "Day targeting" )]
        public List<WADayTargeting> DayTargeting { get; set; }

        [JsonProperty( PropertyName = "Day stats" )]
        public List<WADayTargetingExtend> DayStats { get; set; }

        [JsonProperty( PropertyName = "Week targeting" )]
        public List<WAWeekTargeting> WeekTargeting { get; set; }

        [JsonProperty( PropertyName = "Time distribution" )]
        public List<WATimeDistribution> TimeDistribution { get; set; }

        public WATaskWhole()
        {
            this.GeoTargeting = null;
            this.DayTargeting = null;
            this.DayStats = null;
            this.WeekTargeting = null;
            this.TimeDistribution = null;
        }

        public WATaskWhole( int? taskId, int? listId, int? afterClick, bool allowProxy, bool ignoreGu, double? growth,
            string domain, string profile, bool frozen, bool listMode, int? rangeSize, int? uniquePeriod, string name,
            string mask, int? days, string extSource, int? beforeClick, string profileSorage,
            List<WAGeoTargeting> geoTargeting, List<WADayTargeting> dayTargeting, List<WADayTargetingExtend> dayStats,
            List<WAWeekTargeting> weekTargeting, List<WATimeDistribution> timeDistribution )
            : base( taskId, listId, afterClick, allowProxy, ignoreGu, growth, domain, profile, frozen, listMode,
                rangeSize, uniquePeriod, name, mask, days, extSource, beforeClick, profileSorage )
        {
            this.GeoTargeting = geoTargeting;
            this.DayTargeting = dayTargeting;
            this.DayStats = dayStats;
            this.WeekTargeting = weekTargeting;
            this.TimeDistribution = timeDistribution;
        }

        public WATaskWhole( WATask task, List<WAGeoTargeting> geoTargeting, List<WADayTargeting> dayTargeting,
            List<WADayTargetingExtend> dayStats, List<WAWeekTargeting> weekTargeting,
            List<WATimeDistribution> timeDistribution )
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