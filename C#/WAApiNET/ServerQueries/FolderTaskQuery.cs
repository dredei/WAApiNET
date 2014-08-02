#region Using

using Newtonsoft.Json;

#endregion

namespace WAApiNET.ServerQueries
{
    internal class FolderTaskQuery : BaseQueryData
    {
        [JsonProperty( PropertyName = "Folder ID" )]
        public int? FolderId { get; set; }

        [JsonProperty( PropertyName = "Task ID" )]
        public int? TaskId { get; set; }

        public FolderTaskQuery()
        {
            this.FolderId = null;
            this.TaskId = null;
        }

        public FolderTaskQuery( string token, int? folderId, int? taskId )
            : base( token )
        {
            this.FolderId = folderId;
            this.TaskId = taskId;
        }
    }
}