#region Using

using Newtonsoft.Json;

#endregion

namespace WAApiNET.Model.Folder
{
    public class WAFolder
    {
        [JsonProperty( PropertyName = "Folder ID" )]
        public int? FolderId { get; set; }

        public string Name { get; set; }
        public int? Tasks { get; set; }

        public WAFolder()
        {
            this.FolderId = null;
            this.Name = null;
            this.Tasks = null;
        }

        public WAFolder( int? folderId, string name, int? tasks )
            : this()
        {
            this.FolderId = folderId;
            this.Name = name;
            this.Tasks = null;
        }
    }
}