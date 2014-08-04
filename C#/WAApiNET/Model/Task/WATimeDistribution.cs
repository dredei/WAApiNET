namespace WAApiNET.Model.Task
{
    /// <summary>
    /// Объект временного распределения
    /// </summary>
    public class WATimeDistribution
    {
        /// <summary>
        /// Процент
        /// </summary>
        public int? Percent { get; set; }
        /// <summary>
        /// Приоритет
        /// </summary>
        public int? Priority { get; set; }

        /// <summary>
        /// Создает новый экземпляр, все поля имеют значения null
        /// </summary>
        public WATimeDistribution()
        {
            this.Percent = null;
            this.Priority = null;
        }

        /// <summary>
        /// Создает новый экземпляр с указанными параметрами
        /// </summary>
        /// <param name="percent"></param>
        /// <param name="priority"></param>
        public WATimeDistribution( int percent, int priority )
        {
            this.Percent = percent;
            this.Priority = priority;
        }
    }
}