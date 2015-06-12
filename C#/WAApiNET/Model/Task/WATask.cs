#region Using

using System;
using Newtonsoft.Json;

#endregion

namespace WAApiNET.Model.Task
{
    /// <summary>
    /// Объект задания
    /// </summary>
    public class WATask : IEquatable<WATask>
    {
        /// <summary>
        /// Id задания
        /// </summary>
        [JsonProperty( PropertyName = "Task ID" )]
        public int? TaskId { get; set; }

        /// <summary>
        /// Id списка
        /// </summary>
        [JsonProperty( PropertyName = "List ID" )]
        public int? ListId { get; set; }

        /// <summary>
        /// Время после клика
        /// </summary>
        [JsonProperty( PropertyName = "After click" )]
        public int? AfterClick { get; set; }

        /// <summary>
        /// Разрешить прокси
        /// </summary>
        [JsonProperty( PropertyName = "Allow proxy" )]
        public bool? AllowProxy { get; set; }

        /// <summary>
        /// Игнорировать глобальную уникальность
        /// </summary>
        [JsonProperty( PropertyName = "Ignore GU" )]
        public bool? IgnoreGu { get; set; }

        /// <summary>
        /// Прирост
        /// </summary>
        public double? Growth { get; set; }

        /// <summary>
        /// Домен
        /// </summary>
        public string Domain { get; set; }

        /// <summary>
        /// Имя профиля
        /// </summary>
        public string Profile { get; set; }

        /// <summary>
        /// Статус активации
        /// </summary>
        public bool? Frozen { get; set; }

        /// <summary>
        /// Использовать список IP
        /// </summary>
        [JsonProperty( PropertyName = "List mode" )]
        public bool? ListMode { get; set; }

        /// <summary>
        /// Размер разброса подсети
        /// </summary>
        [JsonProperty( PropertyName = "Range size" )]
        public int? RangeSize { get; set; }

        /// <summary>
        /// Время уникальности
        /// </summary>
        [JsonProperty( PropertyName = "Unique period" )]
        public int? UniquePeriod { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Маска
        /// </summary>
        public string Mask { get; set; }

        /// <summary>
        /// Количество дней работы задания
        /// </summary>
        public int? Days { get; set; }

        /// <summary>
        /// Внешний источник
        /// </summary>
        [JsonProperty( PropertyName = "Ext source" )]
        public string ExtSource { get; set; }

        /// <summary>
        /// Время до клика
        /// </summary>
        [JsonProperty( PropertyName = "Before click" )]
        public int? BeforeClick { get; set; }

        /// <summary>
        /// Ссылка на хранилище профилей
        /// </summary>
        [JsonProperty( PropertyName = "Profile storage" )]
        public string ProfileSorage { get; set; }

        /// <summary>
        /// Создает новый экземпляр, все поля имеют значения null
        /// </summary>
        public WATask()
        {
            this.TaskId = null;
            this.ListId = null;
            this.AfterClick = null;
            this.Growth = null;
            this.Domain = null;
            this.Profile = null;
            this.RangeSize = null;
            this.UniquePeriod = null;
            this.Name = null;
            this.Mask = null;
            this.Days = null;
            this.ExtSource = null;
            this.BeforeClick = null;
            this.ProfileSorage = null;
            this.AllowProxy = null;
            this.IgnoreGu = null;
            this.Frozen = null;
            this.ListMode = null;
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
        public WATask( int? taskId, int? listId, int? afterClick, bool allowProxy, bool ignoreGu, double? growth,
            string domain, string profile, bool frozen, bool listMode, int? rangeSize, int? uniquePeriod, string name,
            string mask, int? days, string extSource, int? beforeClick, string profileSorage )
        {
            this.TaskId = taskId;
            this.ListId = listId;
            this.AfterClick = afterClick;
            this.AllowProxy = allowProxy;
            this.IgnoreGu = ignoreGu;
            this.Growth = growth;
            this.Domain = domain;
            this.Profile = profile;
            this.Frozen = frozen;
            this.ListMode = listMode;
            this.RangeSize = rangeSize;
            this.UniquePeriod = uniquePeriod;
            this.Name = name;
            this.Mask = mask;
            this.Days = days;
            this.ExtSource = extSource;
            this.BeforeClick = beforeClick;
            this.ProfileSorage = profileSorage;
        }

        /// <summary>
        /// Создает новый экземпляр (клонирует указанное задание)
        /// </summary>
        /// <param name="task"></param>
        public WATask( WATask task )
        {
            this.TaskId = task.TaskId;
            this.ListId = task.ListId;
            this.AfterClick = task.AfterClick;
            this.AllowProxy = task.AllowProxy;
            this.IgnoreGu = task.IgnoreGu;
            this.Growth = task.Growth;
            this.Domain = task.Domain;
            this.Profile = task.Profile;
            this.Frozen = task.Frozen;
            this.ListMode = task.ListMode;
            this.RangeSize = task.RangeSize;
            this.UniquePeriod = task.UniquePeriod;
            this.Name = task.Name;
            this.Mask = task.Mask;
            this.Days = task.Days;
            this.ExtSource = task.ExtSource;
            this.BeforeClick = task.BeforeClick;
            this.ProfileSorage = task.ProfileSorage;
        }

        /// <summary>
        /// Нужен для JSON.NET
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeTaskId()
        {
            return false;
        }

        #region Members

        public bool Equals( WATask other )
        {
            if ( ReferenceEquals( null, other ) )
            {
                return false;
            }
            if ( ReferenceEquals( this, other ) )
            {
                return true;
            }
            return this.TaskId == other.TaskId && string.Equals( this.Name, other.Name ) &&
                   string.Equals( this.ProfileSorage, other.ProfileSorage ) && this.BeforeClick == other.BeforeClick &&
                   string.Equals( this.ExtSource, other.ExtSource ) && this.Days == other.Days &&
                   string.Equals( this.Mask, other.Mask ) && this.UniquePeriod == other.UniquePeriod &&
                   this.RangeSize == other.RangeSize && this.ListMode.Equals( other.ListMode ) &&
                   this.Frozen.Equals( other.Frozen ) && string.Equals( this.Profile, other.Profile ) &&
                   string.Equals( this.Domain, other.Domain ) && this.IgnoreGu.Equals( other.IgnoreGu ) &&
                   this.Growth.Equals( other.Growth ) && this.AllowProxy.Equals( other.AllowProxy ) &&
                   this.AfterClick == other.AfterClick && this.ListId == other.ListId;
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
            return this.Equals( (WATask)obj );
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = this.TaskId.GetHashCode();
                hashCode = ( hashCode * 397 ) ^ ( this.Name != null ? this.Name.GetHashCode() : 0 );
                hashCode = ( hashCode * 397 ) ^ ( this.ProfileSorage != null ? this.ProfileSorage.GetHashCode() : 0 );
                hashCode = ( hashCode * 397 ) ^ this.BeforeClick.GetHashCode();
                hashCode = ( hashCode * 397 ) ^ ( this.ExtSource != null ? this.ExtSource.GetHashCode() : 0 );
                hashCode = ( hashCode * 397 ) ^ this.Days.GetHashCode();
                hashCode = ( hashCode * 397 ) ^ ( this.Mask != null ? this.Mask.GetHashCode() : 0 );
                hashCode = ( hashCode * 397 ) ^ this.UniquePeriod.GetHashCode();
                hashCode = ( hashCode * 397 ) ^ this.RangeSize.GetHashCode();
                hashCode = ( hashCode * 397 ) ^ this.ListMode.GetHashCode();
                hashCode = ( hashCode * 397 ) ^ this.Frozen.GetHashCode();
                hashCode = ( hashCode * 397 ) ^ ( this.Profile != null ? this.Profile.GetHashCode() : 0 );
                hashCode = ( hashCode * 397 ) ^ ( this.Domain != null ? this.Domain.GetHashCode() : 0 );
                hashCode = ( hashCode * 397 ) ^ this.IgnoreGu.GetHashCode();
                hashCode = ( hashCode * 397 ) ^ this.Growth.GetHashCode();
                hashCode = ( hashCode * 397 ) ^ this.AllowProxy.GetHashCode();
                hashCode = ( hashCode * 397 ) ^ this.AfterClick.GetHashCode();
                hashCode = ( hashCode * 397 ) ^ this.ListId.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==( WATask left, WATask right )
        {
            return Equals( left, right );
        }

        public static bool operator !=( WATask left, WATask right )
        {
            return !Equals( left, right );
        }

        #endregion
    }
}