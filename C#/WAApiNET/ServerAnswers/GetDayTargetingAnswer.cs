#region Using

using System.Collections.Generic;
using Newtonsoft.Json;
using WAApiNET.Model;

#endregion

namespace WAApiNET.ServerAnswers
{
    internal class GetDayTargetingAnswer : BaseAnswer
    {
        internal class DataObj
        {
            [JsonProperty( PropertyName = "Day targeting" )]
            public List<WADayTargeting> DayTargeting { get; set; }

            public DataObj()
            {
                this.DayTargeting = new List<WADayTargeting>();
            }
        }

        public DataObj Data { get; set; }

        public GetDayTargetingAnswer()
        {
            this.Data = new DataObj();
        }
    }
}