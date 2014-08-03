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
            public List<DayTargeting> DayTargeting { get; set; }

            public DataObj()
            {
                this.DayTargeting = new List<DayTargeting>();
            }
        }

        public DataObj Data { get; set; }

        public GetDayTargetingAnswer()
        {
            this.Data = new DataObj();
        }
    }
}