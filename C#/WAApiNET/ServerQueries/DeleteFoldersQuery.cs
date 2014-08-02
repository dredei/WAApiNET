#region Using

using Newtonsoft.Json;

#endregion

namespace WAApiNET.ServerQueries
{
    internal class DeleteFoldersQuery : BaseQueryData
    {
        [JsonProperty( PropertyName = "Folder IDs" )]
        public int[] FolderIds { get; set; }

        public DeleteFoldersQuery()
        {
            this.FolderIds = null;
        }

        public DeleteFoldersQuery( string token, int[] folderIds )
            : base( token )
        {
            this.FolderIds = folderIds;
        }
    }
}