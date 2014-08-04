#region Using

using System.Collections.Generic;
using Newtonsoft.Json;
using WAApiNET.Model.Task;

#endregion

namespace WAApiNET.ServerAnswers.Task
{
    internal class GetGeoTargetingAnswer : BaseAnswer
    {
        internal class DataObj
        {
            [JsonProperty( PropertyName = "Geo targeting" )]
            public List<WAGeoTargeting> GeoTargeting { get; set; }

            public DataObj()
            {
                this.GeoTargeting = new List<WAGeoTargeting>();
            }
        }

        public DataObj Data { get; set; }

        public GetGeoTargetingAnswer()
        {
            this.Data = new DataObj();
        }
    }
}