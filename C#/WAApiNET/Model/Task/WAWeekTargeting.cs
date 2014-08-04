namespace WAApiNET.Model.Task
{
    /// <summary>
    /// Объект недельнего таргетинга
    /// </summary>
    public class WAWeekTargeting
    {
        /// <summary>
        /// Номер дня (начинается с нуля)
        /// </summary>
        public int? Day { get; set; }
        /// <summary>
        /// Цель (в %)
        /// </summary>
        public double? Target { get; set; }

        /// <summary>
        /// Создает новый экземпляр, все поля имеют значения null
        /// </summary>
        public WAWeekTargeting()
        {
            this.Day = null;
            this.Target = null;
        }

        /// <summary>
        /// Создает новый экземпляр с указанными параметрами
        /// </summary>
        /// <param name="day"></param>
        /// <param name="target"></param>
        public WAWeekTargeting( int? day, double? target )
        {
            this.Day = day;
            this.Target = target;
        }
    }
}