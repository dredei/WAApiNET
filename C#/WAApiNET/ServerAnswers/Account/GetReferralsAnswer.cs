#region Using

using System.Collections.Generic;
using WAApiNET.Model.Account;

#endregion

namespace WAApiNET.ServerAnswers.Account
{
    internal class GetReferralsAnswer : BaseAnswer
    {
        internal class DataObj
        {
            public List<WAReferral> Referrals { get; set; }

            public DataObj()
            {
                this.Referrals = new List<WAReferral>();
            }
        }

        public DataObj Data { get; set; }
    }
}