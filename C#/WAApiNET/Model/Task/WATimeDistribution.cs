#region Using

using System;

#endregion

namespace WAApiNET.Model.Task
{
    /// <summary>
    /// Объект временного распределения
    /// </summary>
    public class WATimeDistribution : IEquatable<WATimeDistribution>
    {
        /// <summary>
        /// Процент
        /// </summary>
        public int? Percent { get; set; }

        /// <summary>
        /// Приоритет
        /// </summary>
        public int? Priority { get; set; }

        /// <summary>
        /// Создает новый экземпляр, все поля имеют значения null
        /// </summary>
        public WATimeDistribution()
        {
            this.Percent = null;
            this.Priority = null;
        }

        /// <summary>
        /// Создает новый экземпляр с указанными параметрами
        /// </summary>
        /// <param name="percent"></param>
        /// <param name="priority"></param>
        public WATimeDistribution( int percent, int priority )
        {
            this.Percent = percent;
            this.Priority = priority;
        }

        #region Members

        public bool Equals( WATimeDistribution other )
        {
            if ( ReferenceEquals( null, other ) )
            {
                return false;
            }
            if ( ReferenceEquals( this, other ) )
            {
                return true;
            }
            return this.Percent == other.Percent && this.Priority == other.Priority;
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
            return this.Equals( (WATimeDistribution)obj );
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ( this.Percent.GetHashCode() * 397 ) ^ this.Priority.GetHashCode();
            }
        }

        public static bool operator ==( WATimeDistribution left, WATimeDistribution right )
        {
            return Equals( left, right );
        }

        public static bool operator !=( WATimeDistribution left, WATimeDistribution right )
        {
            return !Equals( left, right );
        }

        #endregion
    }
}