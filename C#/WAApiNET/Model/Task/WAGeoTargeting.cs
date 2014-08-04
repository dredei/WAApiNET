﻿#region Using

using Newtonsoft.Json;

#endregion

namespace WAApiNET.Model.Task
{
    public class WAGeoTargeting
    {
        [JsonProperty( PropertyName = "Zone ID" )]
        public int ZoneId { get; set; }

        public double Target { get; set; }

        [JsonIgnore]
        public double Recd { get; set; }

        public string Name { get; set; }
    }
}