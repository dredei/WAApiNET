#region Using

using Newtonsoft.Json;

#endregion

namespace WAApiNET.ServerQueries.Task
{
    internal class DeleteTasksQuery : BaseQueryData
    {
        [JsonProperty( PropertyName = "Folder ID" )]
        public int? FolderId { get; set; }

        [JsonProperty( PropertyName = "Task IDs" )]
        public int[] TaskIds { get; set; }

        public DeleteTasksQuery()
        {
            this.FolderId = null;
            this.TaskIds = null;
        }

        public DeleteTasksQuery( string token, int folderId, int[] tasksIds )
            : base( token )
        {
            this.FolderId = folderId;
            this.TaskIds = tasksIds;
        }
    }
}