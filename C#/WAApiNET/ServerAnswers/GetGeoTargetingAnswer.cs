#region Using

using System.Collections.Generic;
using Newtonsoft.Json;
using WAApiNET.Model;

#endregion

namespace WAApiNET.ServerAnswers
{
    internal class GetGeoTargetingAnswer : BaseAnswer
    {
        internal class DataObj
        {
            [JsonProperty( PropertyName = "Geo targeting" )]
            public List<GeoTargeting> GeoTargeting { get; set; }

            public DataObj()
            {
                this.GeoTargeting = new List<GeoTargeting>();
            }
        }

        public DataObj Data { get; set; }

        public GetGeoTargetingAnswer()
        {
            this.Data = new DataObj();
        }
    }
}