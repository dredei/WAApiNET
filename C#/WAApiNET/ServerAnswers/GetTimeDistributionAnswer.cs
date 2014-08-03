﻿#region Using

using System.Collections.Generic;
using Newtonsoft.Json;
using WAApiNET.Model;

#endregion

namespace WAApiNET.ServerAnswers
{
    internal class GetTimeDistributionAnswer : BaseAnswer
    {
        internal class DataObj
        {
            [JsonProperty( PropertyName = "Time distribution" )]
            public List<TimeDistribution> TimeDistribution { get; set; }

            public DataObj()
            {
                this.TimeDistribution = new List<TimeDistribution>();
            }
        }

        public DataObj Data { get; set; }

        public GetTimeDistributionAnswer()
        {
            this.Data = new DataObj();
        }
    }
}