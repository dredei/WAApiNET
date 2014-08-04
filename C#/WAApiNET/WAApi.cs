#region Using

using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using ExtensionMethods;
using Newtonsoft.Json;
using WAApiNET.Categories;
using WAApiNET.Exception;
using WAApiNET.ServerAnswers;

#endregion

namespace WAApiNET
{
    public class WAApi
    {
        private readonly string _address;
        private readonly WebClient _webClient;
        private readonly Timer _waitingTimer;

        #region Поля

        public string Email { get; private set; }
        public string Password { get; private set; }
        public AccountCategory Account { get; private set; }
        public FolderCategory Folder { get; private set; }
        public TaskCategory Task { get; private set; }
        public string LastJSONQuery { get; private set; }
        public string LastJSONAnswer { get; private set; }
        public JsonSerializerSettings JSONSettings { get; private set; }
        public bool Waiting { get; private set; }

        /// <summary>
        /// Срабатывает, когда либа определяет, что нас заблочили антидосом
        /// </summary>
        public event EventHandler<EventArgs> AntiDOSBlocked;

        #endregion

        /// <summary>
        /// Создает новый экземпляр объекта WAApi
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="address"></param>
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
            this._waitingTimer = new Timer { Interval = 500 };
            this._waitingTimer.Elapsed += _waitingTimer_Elapsed;

            this.Account = new AccountCategory( this );
            this.Folder = new FolderCategory( this, this.Account );
            this.Task = new TaskCategory( this, this.Account );
            this.JSONSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
        }

        void _waitingTimer_Elapsed( object sender, ElapsedEventArgs e )
        {
            this.Waiting = false;
            this._waitingTimer.Stop();
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

        public async Task<string> SendPost( string action, string jsonData )
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
            this.Waiting = true;
            this._waitingTimer.Start();
            /* небольшая передышка после выполнения запроса
             * (чтобы сервак не сильно нервничал из-за большого к-ва запросов)
             */
            while ( this.Waiting )
            {
                await TaskEx.Delay( 500 );
            }
            return answer;
        }

        public async Task<string> SendPost( string action, object data )
        {
            string json = JsonConvert.SerializeObject( data, Formatting.None, this.JSONSettings );
            return await this.SendPost( action, json );
        }
    }
}