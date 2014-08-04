#region Using

using Newtonsoft.Json;

#endregion

namespace WAApiNET.ServerQueries.Task
{
    internal class GetTasksQuery : BaseQueryData
    {
        [JsonProperty( PropertyName = "Folder ID" )]
        public int? FolderId { get; set; }

        public GetTasksQuery()
        {
            this.FolderId = null;
        }

        public GetTasksQuery( string token, int? folderId )
            : base( token )
        {
            this.FolderId = folderId;
        }
    }
}