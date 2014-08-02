#region Using

using Newtonsoft.Json;

#endregion

namespace WAApiNET.ServerQueries
{
    internal class ChangeFolderNameQuery : BaseQueryData
    {
        [JsonProperty( PropertyName = "Folder ID" )]
        public int? FolderId { get; set; }

        public string Name { get; set; }

        public ChangeFolderNameQuery()
        {
            this.FolderId = null;
            this.Name = null;
        }

        public ChangeFolderNameQuery( string token, int? folderId, string name )
            : base( token )
        {
            this.FolderId = folderId;
            this.Name = name;
        }
    }
}