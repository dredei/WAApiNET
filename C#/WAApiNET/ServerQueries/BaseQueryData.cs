namespace WAApiNET.ServerQueries
{
    /// <summary>
    /// Объект базового запроса объекта "Data"
    /// </summary>
    public class BaseQueryData
    {
        /// <summary>
        /// Сессионный токен
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Создает новый экземпляр, все поля имеют значения null
        /// </summary>
        public BaseQueryData()
        {
            this.Token = null;
        }

        /// <summary>
        /// Создает новый экземпляр с указанными параметрами
        /// </summary>
        /// <param name="token"></param>
        public BaseQueryData( string token )
        {
            this.Token = token;
        }
    }
}