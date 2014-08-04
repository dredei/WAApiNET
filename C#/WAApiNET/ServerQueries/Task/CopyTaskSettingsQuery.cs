#region Using

using Newtonsoft.Json;
using WAApiNET.Model.Task;

#endregion

namespace WAApiNET.ServerQueries.Task
{
    internal class CopyTaskSettingsQuery : BaseQueryData
    {
        [JsonProperty( PropertyName = "Source folder" )]
        public int? SourceFolder { get; set; }

        [JsonProperty( PropertyName = "Source task" )]
        public int? SourceTask { get; set; }

        [JsonProperty( PropertyName = "Target folder" )]
        public int? TargetFolder { get; set; }

        [JsonProperty( PropertyName = "Target tasks" )]
        public int[] TargetTasks { get; set; }

        public WATaskWhole Settings { get; set; }

        public CopyTaskSettingsQuery()
        {
            this.SourceFolder = null;
            this.SourceTask = null;
            this.TargetFolder = null;
            this.TargetTasks = null;
            this.Settings = null;
        }

        public CopyTaskSettingsQuery( string token, int? sourceFolder, int? sourceTask, int? targetFolder,
            int[] targetTasks, WATaskWhole settings )
            : base( token )
        {
            this.SourceFolder = sourceFolder;
            this.SourceTask = sourceTask;
            this.TargetFolder = targetFolder;
            this.TargetTasks = targetTasks;
            this.Settings = settings;
        }
    }
}