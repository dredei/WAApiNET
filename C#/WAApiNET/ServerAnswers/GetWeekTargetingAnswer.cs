#region Using

using System.Collections.Generic;
using Newtonsoft.Json;
using WAApiNET.Model;

#endregion

namespace WAApiNET.ServerAnswers
{
    internal class GetWeekTargetingAnswer : BaseAnswer
    {
        internal class DataObj
        {
            [JsonProperty( PropertyName = "Week targeting" )]
            public List<WeekTargeting> WeekTargeting { get; set; }

            public DataObj()
            {
                this.WeekTargeting = new List<WeekTargeting>();
            }
        }

        public DataObj Data { get; set; }

        public GetWeekTargetingAnswer()
        {
            this.Data = new DataObj();
        }
    }
}