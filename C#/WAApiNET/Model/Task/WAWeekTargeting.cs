#region Using

using System;

#endregion

namespace WAApiNET.Model.Task
{
    /// <summary>
    /// Объект недельнего таргетинга
    /// </summary>
    public class WAWeekTargeting : IEquatable<WAWeekTargeting>
    {
        /// <summary>
        /// Номер дня (начинается с нуля)
        /// </summary>
        public int? Day { get; set; }

        /// <summary>
        /// Цель (в %)
        /// </summary>
        public double? Target { get; set; }

        /// <summary>
        /// Создает новый экземпляр, все поля имеют значения null
        /// </summary>
        public WAWeekTargeting()
        {
            this.Day = null;
            this.Target = null;
        }

        /// <summary>
        /// Создает новый экземпляр с указанными параметрами
        /// </summary>
        /// <param name="day"></param>
        /// <param name="target"></param>
        public WAWeekTargeting( int? day, double? target )
        {
            this.Day = day;
            this.Target = target;
        }

        #region Members

        public bool Equals( WAWeekTargeting other )
        {
            if ( ReferenceEquals( null, other ) )
            {
                return false;
            }
            if ( ReferenceEquals( this, other ) )
            {
                return true;
            }
            return this.Day == other.Day && this.Target.Equals( other.Target );
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
            return this.Equals( (WAWeekTargeting)obj );
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ( this.Day.GetHashCode() * 397 ) ^ this.Target.GetHashCode();
            }
        }

        public static bool operator ==( WAWeekTargeting left, WAWeekTargeting right )
        {
            return Equals( left, right );
        }

        public static bool operator !=( WAWeekTargeting left, WAWeekTargeting right )
        {
            return !Equals( left, right );
        }

        #endregion
    }
}