#region Using

using System.Collections.Generic;

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