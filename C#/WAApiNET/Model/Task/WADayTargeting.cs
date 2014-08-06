#region Using

using System;

#endregion

namespace WAApiNET.Model.Task
{
    /// <summary>
    /// Объект суточного таргетинга
    /// </summary>
    public class WADayTargeting : IEquatable<WADayTargeting>
    {
        /// <summary>
        /// Минимум
        /// </summary>
        public int? Min { get; set; }

        /// <summary>
        /// Маскимум
        /// </summary>
        public int? Max { get; set; }

        /// <summary>
        /// Время (часы)
        /// </summary>
        public int? Hour { get; set; }

        /// <summary>
        /// Создает новый экземпляр, все поля имеют значения null
        /// </summary>
        public WADayTargeting()
        {
            this.Min = null;
            this.Max = null;
            this.Hour = null;
        }

        /// <summary>
        /// Создает новый экземпляр с указанными параметрами
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="hour"></param>
        public WADayTargeting( int? min, int? max, int? hour )
        {
            this.Min = min;
            this.Max = max;
            this.Hour = hour;
        }

        #region Members

        public bool Equals( WADayTargeting other )
        {
            if ( ReferenceEquals( null, other ) )
            {
                return false;
            }
            if ( ReferenceEquals( this, other ) )
            {
                return true;
            }
            return this.Min == other.Min && this.Max == other.Max && this.Hour == other.Hour;
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
            return this.Equals( (WADayTargeting)obj );
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = this.Min.GetHashCode();
                hashCode = ( hashCode * 397 ) ^ this.Max.GetHashCode();
                hashCode = ( hashCode * 397 ) ^ this.Hour.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==( WADayTargeting left, WADayTargeting right )
        {
            return Equals( left, right );
        }

        public static bool operator !=( WADayTargeting left, WADayTargeting right )
        {
            return !Equals( left, right );
        }

        #endregion
    }
}