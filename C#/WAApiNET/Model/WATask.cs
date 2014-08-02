#region Using

using Newtonsoft.Json;

#endregion

namespace WAApiNET.Model
{
    public class WATask
    {
        [JsonProperty( PropertyName = "Task ID" )]
        public int? TaskId { get; set; }

        [JsonProperty( PropertyName = "List ID" )]
        public int? ListId { get; set; }

        [JsonProperty( PropertyName = "After click" )]
        public int? AfterClick { get; set; }

        [JsonProperty( PropertyName = "Allow proxy" )]
        public bool AllowProxy { get; set; }

        [JsonProperty( PropertyName = "Ignore GU" )]
        public bool IgnoreGu { get; set; }

        public double? Growth { get; set; }
        public string Domain { get; set; }
        public string Profile { get; set; }
        public bool Frozen { get; set; }

        [JsonProperty( PropertyName = "List mode" )]
        public bool ListMode { get; set; }

        [JsonProperty( PropertyName = "Range size" )]
        public int? RangeSize { get; set; }

        [JsonProperty( PropertyName = "Unique period" )]
        public int? UniquePeriod { get; set; }

        public string Name { get; set; }
        public string Mask { get; set; }
        public int? Days { get; set; }

        [JsonProperty( PropertyName = "Ext source" )]
        public string ExtSource { get; set; }

        [JsonProperty( PropertyName = "Before click" )]
        public int? BeforeClick { get; set; }

        [JsonProperty( PropertyName = "Profile storage" )]
        public string ProfileSorage { get; set; }

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
        }

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