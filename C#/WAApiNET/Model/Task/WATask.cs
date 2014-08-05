#region Using

using Newtonsoft.Json;

#endregion

namespace WAApiNET.Model.Task
{
    /// <summary>
    /// Объект задания
    /// </summary>
    public class WATask
    {
        /// <summary>
        /// Id задания
        /// </summary>
        [JsonIgnore]
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
    }
}