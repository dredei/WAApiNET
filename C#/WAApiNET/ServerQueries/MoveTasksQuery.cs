#region Using

using Newtonsoft.Json;

#endregion

namespace WAApiNET.ServerQueries
{
    internal class MoveTasksQuery : BaseQueryData
    {
        [JsonProperty( PropertyName = "Source folder" )]
        public int? SourceFolder { get; set; }

        [JsonProperty( PropertyName = "Target folder" )]
        public int? TargetFolder { get; set; }

        [JsonProperty( PropertyName = "Task IDs" )]
        public int[] TaskIds { get; set; }

        public MoveTasksQuery()
        {
            this.SourceFolder = null;
            this.TargetFolder = null;
            this.TaskIds = null;
        }

        public MoveTasksQuery( string token, int sourceFolder, int targetFolder, int[] taskIds )
            : base( token )
        {
            this.SourceFolder = sourceFolder;
            this.TargetFolder = targetFolder;
            this.TaskIds = taskIds;
        }
    }
}