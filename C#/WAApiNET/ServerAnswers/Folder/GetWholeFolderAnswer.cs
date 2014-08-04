#region Using

using WAApiNET.Model.Folder;

#endregion

namespace WAApiNET.ServerAnswers.Folder
{
    internal class GetWholeFolderAnswer : BaseAnswer
    {
        internal class DataObj
        {
            public WAFolderWhole Folder { get; set; }

            public DataObj()
            {
                this.Folder = null;
            }
        }

        public DataObj Data { get; set; }

        public GetWholeFolderAnswer()
        {
            this.Data = null;
        }
    }
}