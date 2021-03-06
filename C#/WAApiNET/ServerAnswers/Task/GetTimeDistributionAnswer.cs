﻿#region Using

using System.Collections.Generic;
using Newtonsoft.Json;
using WAApiNET.Model.Task;

#endregion

namespace WAApiNET.ServerAnswers.Task
{
    internal class GetTimeDistributionAnswer : BaseAnswer
    {
        internal class DataObj
        {
            [JsonProperty( PropertyName = "Time distribution" )]
            public List<WATimeDistribution> TimeDistribution { get; set; }

            public DataObj()
            {
                this.TimeDistribution = new List<WATimeDistribution>();
            }
        }

        public DataObj Data { get; set; }

        public GetTimeDistributionAnswer()
        {
            this.Data = new DataObj();
        }
    }
}