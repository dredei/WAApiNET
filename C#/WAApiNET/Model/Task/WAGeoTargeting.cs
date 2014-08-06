#region Using

using System;
using Newtonsoft.Json;

#endregion

namespace WAApiNET.Model.Task
{
    /// <summary>
    /// Объект геотаргетинга
    /// </summary>
    public class WAGeoTargeting : IEquatable<WAGeoTargeting>
    {
        /// <summary>
        /// Id зоны
        /// </summary>
        [JsonProperty( PropertyName = "Zone ID" )]
        public int ZoneId { get; set; }

        /// <summary>
        /// Цель (сколько нужно, в %)
        /// </summary>
        public double Target { get; set; }

        /// <summary>
        /// Выполнено
        /// </summary>
        [JsonIgnore]
        public double Recd { get; set; }

        /// <summary>
        /// Имя (не всегда указано)
        /// </summary>
        [JsonIgnore]
        public string Name { get; set; }

        #region Members

        public bool Equals( WAGeoTargeting other )
        {
            if ( ReferenceEquals( null, other ) )
            {
                return false;
            }
            if ( ReferenceEquals( this, other ) )
            {
                return true;
            }
            return this.ZoneId == other.ZoneId && this.Target.Equals( other.Target );
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
            return this.Equals( (WAGeoTargeting)obj );
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ( this.ZoneId * 397 ) ^ this.Target.GetHashCode();
            }
        }

        public static bool operator ==( WAGeoTargeting left, WAGeoTargeting right )
        {
            return Equals( left, right );
        }

        public static bool operator !=( WAGeoTargeting left, WAGeoTargeting right )
        {
            return !Equals( left, right );
        }

        #endregion
    }
}