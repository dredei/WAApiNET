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
            public List<WAFolder> Folders { get; set; }

            public DataObj()
            {
                this.Folders = new List<WAFolder>();
            }
        }

        public DataObj Data { get; set; }
    }
}