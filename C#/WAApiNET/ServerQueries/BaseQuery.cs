namespace WAApiNET.ServerQueries
{
    /// <summary>
    /// Объект базового запроса
    /// </summary>
    public abstract class BaseQuery
    {
        /// <summary>
        /// Тип действия
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// Создает новый экземпляр, все поля имеют значения null
        /// </summary>
        public BaseQuery()
        {
            this.Action = null;
        }
    }
}