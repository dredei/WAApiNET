#region Using

using Newtonsoft.Json;

#endregion

namespace WAApiNET.ServerAnswers
{
    internal class AddFolderAnswer : BaseAnswer
    {
        internal class DataObj
        {
            [JsonProperty( PropertyName = "Folder ID" )]
            public int? FolderId { get; set; }

            public DataObj()
            {
                this.FolderId = null;
            }
        }

        public DataObj Data { get; set; }

        public AddFolderAnswer()
        {
            this.Data = new DataObj();
        }
    }
}