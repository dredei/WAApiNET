#region Using

using System.Collections.Generic;
using WAApiNET.Model;

#endregion

namespace WAApiNET.ServerAnswers
{
    internal class GetFoldersAnswer : BaseAnswer
    {
        internal class DataObj
        {
            public List<Folder> Folders { get; set; }

            public DataObj()
            {
                this.Folders = new List<Folder>();
            }
        }

        public DataObj Data { get; set; }
    }
}