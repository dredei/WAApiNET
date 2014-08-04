namespace WAApiNET.Model.Task
{
    /// <summary>
    /// Объект суточного таргетинга
    /// </summary>
    public class WADayTargeting
    {
        /// <summary>
        /// Минимум
        /// </summary>
        public int? Min { get; set; }
        /// <summary>
        /// Маскимум
        /// </summary>
        public int? Max { get; set; }
        /// <summary>
        /// Время (часы)
        /// </summary>
        public int? Hour { get; set; }

        /// <summary>
        /// Создает новый экземпляр, все поля имеют значения null
        /// </summary>
        public WADayTargeting()
        {
            this.Min = null;
            this.Max = null;
            this.Hour = null;
        }

        /// <summary>
        /// Создает новый экземпляр с указанными параметрами
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="hour"></param>
        public WADayTargeting( int? min, int? max, int? hour )
        {
            this.Min = min;
            this.Max = max;
            this.Hour = hour;
        }
    }
}