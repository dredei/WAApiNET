#region Using

using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ExtensionMethods;
using Newtonsoft.Json;
using WAApiNET.Categories;
using WAApiNET.Exception;
using WAApiNET.ServerAnswers;

#endregion

namespace WAApiNET
{
    /// <summary>
    /// Главный класс для работы с WaspAce API
    /// </summary>
    public class WAApi
    {
        private readonly string _address;
        private readonly WebClient _webClient;

        #region Поля

        /// <summary>
        /// Почта
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; private set; }

        /// <summary>
        /// Методы для работы с аккаунтом
        /// </summary>
        public AccountCategory Account { get; private set; }

        /// <summary>
        /// Методы для работы с папками
        /// </summary>
        public FolderCategory Folder { get; private set; }

        /// <summary>
        /// Методы для работы с заданиями
        /// </summary>
        public TaskCategory Task { get; private set; }

        /// <summary>
        /// Последний JSON запрос
        /// </summary>
        public string LastJSONQuery { get; private set; }

        /// <summary>
        /// Последний JSON ответ
        /// </summary>
        public string LastJSONAnswer { get; private set; }

        /// <summary>
        /// Настройки сериализации
        /// </summary>
        public JsonSerializerSettings JSONSettings { get; private set; }

        /// <summary>
        /// Срабатывает, когда либа определяет, что нас заблочили антидосом
        /// </summary>
        public event EventHandler<EventArgs> AntiDOSBlocked;

        #endregion

        /// <summary>
        /// Создает новый экземпляр объекта WAApi
        /// </summary>
        /// <param name="email">Почта</param>
        /// <param name="password">Пароль</param>
        /// <param name="address">Адрес сервера</param>
        public WAApi( string email, string password, string address = "http://api.waspace.net" )
        {
            if ( address[ address.Length - 1 ] == '/' )
            {
                address = address.Remove( address.Length - 1, 1 );
            }
            this.Email = email;
            this.Password = password;
            this._address = address;
            this._webClient = new WebClient { Encoding = Encoding.UTF8 };

            this.Account = new AccountCategory( this );
            this.Folder = new FolderCategory( this, this.Account );
            this.Task = new TaskCategory( this, this.Account );
            this.JSONSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
        }

        private async Task<bool> IsAntiDOSBlocked( string answer, string jsonData )
        {
            var baseAnswer = JsonConvert.DeserializeObject<BaseAnswer>( answer );
            if ( baseAnswer.Status == "Success" )
            {
                return false;
            }
            var errorAnswer = JsonConvert.DeserializeObject<ErrorAnswer>( answer );
            if ( !errorAnswer.Error.IsNullOrEmpty() && errorAnswer.Error == "AntiDOS block" )
            {
                var handler = this.AntiDOSBlocked;
                if ( handler != null )
                {
                    // генерируем событие, что нас заблочили антидосом
                    handler( this, new EventArgs() );
                }
                await TaskEx.Delay( 65000 );
                return true;
            }
            throw new WAApiException( "Ошибка \"{0}\"!".F( errorAnswer.Error ), jsonData, answer );
        }

        /// <summary>
        /// Отправляет GET-запрос серверу
        /// </summary>
        /// <param name="action">Тип действия</param>
        /// <param name="jsonData">Данные</param>
        /// <returns>Возвращает ответ от сервера</returns>
        /// <exception cref="WAApiException">Когда не авторизовались или произошла другая ошибка</exception>
        public async Task<string> SendGet( string action, string jsonData )
        {
            if ( this.Account.Token.IsNullOrEmpty() && action != "Sign in" )
            {
                throw new WAApiException( "Сначала авторизуйтесь!" );
            }
            this.LastJSONQuery = jsonData;
            string url = "{0}/{1}/{2}".F( this._address, action, jsonData );
            string answer;
            do
            {
                answer = this._webClient.DownloadString( url );
                this.LastJSONAnswer = answer;
            }
            while ( await this.IsAntiDOSBlocked( answer, jsonData ) );
            /* небольшая передышка после выполнения запроса
             * (чтобы сервак не сильно нервничал из-за большого к-ва запросов)
             */
            await TaskEx.Delay( 500 );
            return answer;
        }

        /// <summary>
        /// Отправляет GET-запрос серверу
        /// </summary>
        /// <param name="action">Тип действия</param>
        /// <param name="data">Объект с данными</param>
        /// <returns>Возвращает ответ от сервера</returns>
        public async Task<string> SendGet( string action, object data )
        {
            string json = JsonConvert.SerializeObject( data, Formatting.None, this.JSONSettings );
            return await this.SendGet( action, json );
        }
    }
}