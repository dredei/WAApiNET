#region Using

#endregion

/* Пример ошибки:
 * {"Status":"General error","Error":"AntiDOS block"}
 */


namespace WAApiNET.Exception
{
    /// <summary>
    /// Класс для всех исключений, выбрасываемый библиотекой
    /// </summary>
    public class WAApiException : System.Exception
    {
        /// <summary>
        /// Исключение
        /// </summary>
        public System.Exception Exception { get; private set; }

        /// <summary>
        /// JSON запрос
        /// </summary>
        public string JSONQuery { get; private set; }

        /// <summary>
        /// JSON ответ
        /// </summary>
        public string JSONAnswer { get; private set; }

        /// <summary>
        /// Сообщение об ошибке
        /// </summary>
        public new string Message { get; private set; }

        /// <summary>
        /// Создает новый экземпляр
        /// </summary>
        public WAApiException()
        {
            this.Exception = null;
            this.Message = null;
            this.JSONQuery = null;
            this.JSONAnswer = null;
        }

        /// <summary>
        /// Создает новый экземпляр
        /// </summary>
        /// <param name="exception">Исключение</param>
        /// <param name="jsonQuery">JSON запрос</param>
        /// <param name="jsonAnswer">JSON ответ</param>
        public WAApiException( System.Exception exception, string jsonQuery, string jsonAnswer )
            : this()
        {
            this.Exception = exception;
            this.Message = exception.Message;
            this.JSONQuery = jsonQuery;
            this.JSONAnswer = jsonAnswer;
        }

        /// <summary>
        /// Создает новый экземпляр
        /// </summary>
        /// <param name="message">Сообщение</param>
        /// <param name="jsonQuery">JSON запрос</param>
        /// <param name="jsonAnswer">JSON ответ</param>
        public WAApiException( string message, string jsonQuery = "", string jsonAnswer = "" )
            : this()
        {
            this.Exception = new System.Exception( message );
            this.Message = message;
            this.JSONQuery = jsonQuery;
            this.JSONAnswer = jsonAnswer;
        }

        public override string ToString()
        {
            return string.Format( "Message: {0}, JSONAnswer: {1}, JSONQuery: {2}", this.Message, this.JSONAnswer,
                this.JSONQuery );
        }
    }
}