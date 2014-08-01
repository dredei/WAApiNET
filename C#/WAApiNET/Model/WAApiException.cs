#region Using

using System;

#endregion

namespace WAApiNET.Model
{
    /// <summary>
    /// Класс для всех исключений, выбрасываемый библиотекой
    /// </summary>
    public class WAApiException : Exception
    {
        public Exception Exception { get; private set; }
        public string JSONQuery { get; private set; }
        public string JSONAnswer { get; private set; }

        public WAApiException()
        {
            this.Exception = null;
            this.JSONQuery = null;
            this.JSONAnswer = null;
        }

        public WAApiException( Exception exception, string jsonQuery, string jsonAnswer )
            : this()
        {
            this.Exception = exception;
            this.JSONQuery = jsonQuery;
            this.JSONAnswer = jsonAnswer;
        }

        public WAApiException( string message, string jsonQuery = "", string jsonAnswer = "" )
            : this()
        {
            this.Exception = new Exception( message );
            this.JSONQuery = jsonQuery;
            this.JSONAnswer = jsonAnswer;
        }
    }
}