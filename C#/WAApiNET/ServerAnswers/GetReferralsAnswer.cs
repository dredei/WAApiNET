﻿#region Using

using System.Collections.Generic;
using WAApiNET.Model;

#endregion

namespace WAApiNET.ServerAnswers
{
    internal class GetReferralsAnswer : BaseAnswer
    {
        internal class DataObj
        {
            public List<Referral> Referrals { get; set; }

            public DataObj()
            {
                this.Referrals = new List<Referral>();
            }
        }

        public DataObj Data { get; set; }
    }
}