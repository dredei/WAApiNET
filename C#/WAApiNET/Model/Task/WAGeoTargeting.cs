#region Using

using Newtonsoft.Json;

#endregion

namespace WAApiNET.Model.Task
{
    /// <summary>
    /// Объект геотаргетинга
    /// </summary>
    public class WAGeoTargeting
    {
        /// <summary>
        /// Id зоны
        /// </summary>
        [JsonProperty( PropertyName = "Zone ID" )]
        public int ZoneId { get; set; }

        /// <summary>
        /// Цель (сколько нужно, в %)
        /// </summary>
        public double Target { get; set; }

        /// <summary>
        /// Выполнено
        /// </summary>
        [JsonIgnore]
        public double Recd { get; set; }

        /// <summary>
        /// Имя (не всегда указано)
        /// </summary>
        public string Name { get; set; }
    }
}