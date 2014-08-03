#region Using

using System.Collections.Generic;
using Newtonsoft.Json;
using WAApiNET.Model;

#endregion

namespace WAApiNET.ServerAnswers
{
    internal class GetDaysStatsAnswer : BaseAnswer
    {
        internal class DataObj
        {
            [JsonProperty( PropertyName = "Day targeting" )]
            public List<DayTargetingExtend> DayTargeting { get; set; }

            public DataObj()
            {
                this.DayTargeting = new List<DayTargetingExtend>();
            }
        }

        public DataObj Data { get; set; }

        public GetDaysStatsAnswer()
        {
            this.Data = new DataObj();
        }
    }
}