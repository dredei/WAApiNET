#region Using

using Newtonsoft.Json;

#endregion

namespace WAApiNET.ServerQueries
{
    internal class GetWholeFolderQuery : BaseQueryData
    {
        [JsonProperty( PropertyName = "Folder ID" )]
        public int? FolderId { get; set; }

        public GetWholeFolderQuery()
        {
            this.FolderId = null;
        }

        public GetWholeFolderQuery( string token, int folderId )
            : base( token )
        {
            this.FolderId = folderId;
        }
    }
}