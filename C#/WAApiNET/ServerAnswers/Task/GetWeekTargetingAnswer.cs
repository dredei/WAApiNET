#region Using

using System.Collections.Generic;
using Newtonsoft.Json;
using WAApiNET.Model.Task;

#endregion

namespace WAApiNET.ServerAnswers.Task
{
    internal class GetWeekTargetingAnswer : BaseAnswer
    {
        internal class DataObj
        {
            [JsonProperty( PropertyName = "Week targeting" )]
            public List<WAWeekTargeting> WeekTargeting { get; set; }

            public DataObj()
            {
                this.WeekTargeting = new List<WAWeekTargeting>();
            }
        }

        public DataObj Data { get; set; }

        public GetWeekTargetingAnswer()
        {
            this.Data = new DataObj();
        }
    }
}