#region Using

using System;
using Newtonsoft.Json;

#endregion

namespace WAApiNET.Model.Task
{
    /// <summary>
    /// Объект суточного таргетинга (с к-вом выполненных и незавершенных)
    /// </summary>
    public class WADayTargetingExtend : WADayTargeting, IEquatable<WADayTargetingExtend>
    {
        /// <summary>
        /// Выполнено
        /// </summary>
        [JsonIgnore]
        public int? Recd { get; set; }

        /// <summary>
        /// Незавершено (не найдена маска)
        /// </summary>
        [JsonIgnore]
        public int? Incomplete { get; set; }

        /// <summary>
        /// Незавершено (высокое потребление ресурсов)
        /// </summary>
        [JsonIgnore]
        public int? Overload { get; set; }

        /// <summary>
        /// Создает новый экземпляр, все поля имеют значения null
        /// </summary>
        public WADayTargetingExtend()
        {
            this.Recd = null;
            this.Incomplete = null;
            this.Overload = null;
        }

        /// <summary>
        /// Создает новый экземпляр с указанными параметрами
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="hour"></param>
        /// <param name="recd"></param>
        /// <param name="incomplete"></param>
        /// <param name="overload"></param>
        public WADayTargetingExtend( int? min, int? max, int? hour, int? recd, int? incomplete, int? overload )
            : base( min, max, hour )
        {
            this.Recd = recd;
            this.Incomplete = incomplete;
            this.Overload = overload;
        }

        #region Members

        public bool Equals( WADayTargetingExtend other )
        {
            if ( ReferenceEquals( null, other ) )
            {
                return false;
            }
            if ( ReferenceEquals( this, other ) )
            {
                return true;
            }
            return base.Equals( other ) && this.Recd == other.Recd && this.Incomplete == other.Incomplete &&
                   this.Overload == other.Overload;
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
            return this.Equals( (WADayTargetingExtend)obj );
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = base.GetHashCode();
                hashCode = ( hashCode * 397 ) ^ this.Recd.GetHashCode();
                hashCode = ( hashCode * 397 ) ^ this.Incomplete.GetHashCode();
                hashCode = ( hashCode * 397 ) ^ this.Overload.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==( WADayTargetingExtend left, WADayTargetingExtend right )
        {
            return Equals( left, right );
        }

        public static bool operator !=( WADayTargetingExtend left, WADayTargetingExtend right )
        {
            return !Equals( left, right );
        }

        #endregion
    }
}