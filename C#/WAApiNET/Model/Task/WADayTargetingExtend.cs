namespace WAApiNET.Model.Task
{
    /// <summary>
    /// Объект суточного таргетинга (с к-вом выполненных и незавершенных)
    /// </summary>
    public class WADayTargetingExtend : WADayTargeting
    {
        /// <summary>
        /// Выполнено
        /// </summary>
        public int? Recd { get; set; }
        /// <summary>
        /// Незавершено (не найдена маска)
        /// </summary>
        public int? Incomplete { get; set; }
        /// <summary>
        /// Незавершено (высокое потребление ресурсов)
        /// </summary>
        public int? Overload { get; set; }

        /// <summary>
        /// Создает новый экземпляр, все поля имеют значения null
        /// </summary>
        public WADayTargetingExtend()
        {
            this.Recd = null;
            this.Incomplete = null;
            this.Overload = null;
        }

        /// <summary>
        /// Создает новый экземпляр с указанными параметрами
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="hour"></param>
        /// <param name="recd"></param>
        /// <param name="incomplete"></param>
        /// <param name="overload"></param>
        public WADayTargetingExtend( int? min, int? max, int? hour, int? recd, int? incomplete, int? overload )
            : base( min, max, hour )
        {
            this.Recd = recd;
            this.Incomplete = incomplete;
            this.Overload = overload;
        }
    }
}