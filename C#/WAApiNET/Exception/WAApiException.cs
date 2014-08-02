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
        public System.Exception Exception { get; private set; }
        public string JSONQuery { get; private set; }
        public string JSONAnswer { get; private set; }

        public WAApiException()
        {
            this.Exception = null;
            this.JSONQuery = null;
            this.JSONAnswer = null;
        }

        public WAApiException( System.Exception exception, string jsonQuery, string jsonAnswer )
            : this()
        {
            this.Exception = exception;
            this.JSONQuery = jsonQuery;
            this.JSONAnswer = jsonAnswer;
        }

        public WAApiException( string message, string jsonQuery = "", string jsonAnswer = "" )
            : this()
        {
            this.Exception = new System.Exception( message );
            this.JSONQuery = jsonQuery;
            this.JSONAnswer = jsonAnswer;
        }
    }
}