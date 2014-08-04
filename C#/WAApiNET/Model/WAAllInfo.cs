#region Using

using System.Collections.Generic;
using WAApiNET.Model.Account;
using WAApiNET.Model.Folder;

#endregion

namespace WAApiNET.Model
{
    public class WAAllInfo
    {
        public List<WAFolderWhole> Folders { get; set; }
        public List<WAReferral> Referrals { get; set; }

        public WAAllInfo()
        {
            this.Folders = null;
            this.Referrals = null;
        }
    }
}