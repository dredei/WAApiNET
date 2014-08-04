#region Using

using Newtonsoft.Json;

#endregion

namespace WAApiNET.ServerQueries.Task
{
    internal class CloneTaskQuery : BaseQueryData
    {
        [JsonProperty( PropertyName = "Folder ID" )]
        public int? FolderId { get; set; }

        [JsonProperty( PropertyName = "Target ID" )]
        public int? TargetId { get; set; }

        [JsonProperty( PropertyName = "Task ID" )]
        public int? TaskId { get; set; }

        public string Name { get; set; }

        public CloneTaskQuery()
        {
            this.FolderId = null;
            this.TargetId = null;
            this.TaskId = null;
            this.Name = null;
        }

        public CloneTaskQuery( string token, int? folderId, int? targetId, int? taskId, string name )
            : base( token )
        {
            this.FolderId = folderId;
            this.TargetId = targetId;
            this.TaskId = taskId;
            this.Name = name;
        }
    }
}