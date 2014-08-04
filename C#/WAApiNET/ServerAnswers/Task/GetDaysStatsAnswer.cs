#region Using

using System.Collections.Generic;
using Newtonsoft.Json;
using WAApiNET.Model.Task;

#endregion

namespace WAApiNET.ServerAnswers.Task
{
    internal class GetDaysStatsAnswer : BaseAnswer
    {
        internal class DataObj
        {
            [JsonProperty( PropertyName = "Day targeting" )]
            public List<WADayTargetingExtend> DayTargeting { get; set; }

            public DataObj()
            {
                this.DayTargeting = new List<WADayTargetingExtend>();
            }
        }

        public DataObj Data { get; set; }

        public GetDaysStatsAnswer()
        {
            this.Data = new DataObj();
        }
    }
}