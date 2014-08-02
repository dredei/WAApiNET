#region Using

using System.Collections.Generic;
using Newtonsoft.Json;

#endregion

namespace WAApiNET.Model
{
    public class Folder
    {
        [JsonProperty( PropertyName = "Folder ID" )]
        public int? FolderId { get; set; }

        public string Name { get; set; }
        public int? Tasks { get; set; }

        public Folder()
        {
            this.FolderId = null;
            this.Name = null;
            this.Tasks = null;
        }

        public Folder( int? folderId, string name, int? tasks )
            : this()
        {
            this.FolderId = folderId;
            this.Name = name;
            this.Tasks = null;
        }
    }
}