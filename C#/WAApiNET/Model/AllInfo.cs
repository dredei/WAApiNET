#region Using

using System.Collections.Generic;

#endregion

namespace WAApiNET.Model
{
    public class AllInfo
    {
        public List<FolderWhole> Folders { get; set; }
        public List<Referral> Referrals { get; set; }

        public AllInfo()
        {
            this.Folders = null;
            this.Referrals = null;
        }
    }
}