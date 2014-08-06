#region Using

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

#endregion

namespace WAApiNET.Model.Task
{
    /// <summary>
    /// Объект задания (с геотаргетингом, суточным, недельным таргетингами, суточной статистикой и временным распределением
    /// </summary>
    public class WATaskWhole : WATask, IEquatable<WATaskWhole>
    {
        /// <summary>
        /// Настройки геотаргетинга
        /// </summary>
        [JsonProperty( PropertyName = "Geo targeting" )]
        public List<WAGeoTargeting> GeoTargeting { get; set; }

        /// <summary>
        /// Настройки суточного таргетинга
        /// </summary>
        [JsonProperty( PropertyName = "Day targeting" )]
        public List<WADayTargeting> DayTargeting { get; set; }

        /// <summary>
        /// Дневная статистика выполнений
        /// </summary>
        [JsonIgnore]
        [JsonProperty( PropertyName = "Day stats" )]
        public List<WADayTargetingExtend> DayStats { get; set; }

        /// <summary>
        /// Настройки недельного таргетинга
        /// </summary>
        [JsonProperty( PropertyName = "Week targeting" )]
        public List<WAWeekTargeting> WeekTargeting { get; set; }

        /// <summary>
        /// Настройки временного распределения
        /// </summary>
        [JsonProperty( PropertyName = "Time distribution" )]
        public List<WATimeDistribution> TimeDistribution { get; set; }

        /// <summary>
        /// Создает новый экземпляр, все поля имеют значения null
        /// </summary>
        public WATaskWhole()
        {
            this.GeoTargeting = null;
            this.DayTargeting = null;
            this.DayStats = null;
            this.WeekTargeting = null;
            this.TimeDistribution = null;
        }

        /// <summary>
        /// Создает новый экземпляр с указанными параметрами
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="listId"></param>
        /// <param name="afterClick"></param>
        /// <param name="allowProxy"></param>
        /// <param name="ignoreGu"></param>
        /// <param name="growth"></param>
        /// <param name="domain"></param>
        /// <param name="profile"></param>
        /// <param name="frozen"></param>
        /// <param name="listMode"></param>
        /// <param name="rangeSize"></param>
        /// <param name="uniquePeriod"></param>
        /// <param name="name"></param>
        /// <param name="mask"></param>
        /// <param name="days"></param>
        /// <param name="extSource"></param>
        /// <param name="beforeClick"></param>
        /// <param name="profileSorage"></param>
        /// <param name="geoTargeting"></param>
        /// <param name="dayTargeting"></param>
        /// <param name="dayStats"></param>
        /// <param name="weekTargeting"></param>
        /// <param name="timeDistribution"></param>
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

        /// <summary>
        /// Создает новый экземпляр (клонирует указанное задание и добавляет дополнительные настройки)
        /// </summary>
        /// <param name="task"></param>
        /// <param name="geoTargeting"></param>
        /// <param name="dayTargeting"></param>
        /// <param name="dayStats"></param>
        /// <param name="weekTargeting"></param>
        /// <param name="timeDistribution"></param>
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

        #region Members

        public bool Equals( WATaskWhole other )
        {
            if ( ReferenceEquals( null, other ) )
            {
                return false;
            }
            if ( ReferenceEquals( this, other ) )
            {
                return true;
            }
            return base.Equals( other ) && Equals( this.GeoTargeting, other.GeoTargeting ) &&
                   Equals( this.DayTargeting, other.DayTargeting ) && Equals( this.WeekTargeting, other.WeekTargeting ) &&
                   Equals( this.TimeDistribution, other.TimeDistribution );
        }

        public override bool Equals( object obj )
        {
            if ( ReferenceEquals( null, obj ) )
            {
                return false;
            }
            if ( ReferenceEquals( this, obj ) )
            {
                return true;
            }
            if ( obj.GetType() != this.GetType() )
            {
                return false;
            }
            return this.Equals( (WATaskWhole)obj );
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = base.GetHashCode();
                hashCode = ( hashCode * 397 ) ^ ( this.GeoTargeting != null ? this.GeoTargeting.GetHashCode() : 0 );
                hashCode = ( hashCode * 397 ) ^ ( this.DayTargeting != null ? this.DayTargeting.GetHashCode() : 0 );
                hashCode = ( hashCode * 397 ) ^ ( this.WeekTargeting != null ? this.WeekTargeting.GetHashCode() : 0 );
                hashCode = ( hashCode * 397 ) ^
                           ( this.TimeDistribution != null ? this.TimeDistribution.GetHashCode() : 0 );
                return hashCode;
            }
        }

        public static bool operator ==( WATaskWhole left, WATaskWhole right )
        {
            return Equals( left, right );
        }

        public static bool operator !=( WATaskWhole left, WATaskWhole right )
        {
            return !Equals( left, right );
        }

        #endregion
    }
}