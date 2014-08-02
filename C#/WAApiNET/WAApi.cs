#region Using

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
    public class WAApi
    {
        private readonly string _address;
        private readonly WebClient _webClient;

        private const int MaxQueries = 20;
        private const int RestTime = 30000;

        #region Поля

        public string Email { get; private set; }
        public string Password { get; private set; }
        public AccountCategory Account { get; private set; }
        public FolderCategory Folder { get; private set; }
        public TaskCategory Task { get; private set; }
        public int Queries { get; private set; }
        public string LastJSONQuery { get; private set; }
        public string LastJSONAnswer { get; private set; }
        public JsonSerializerSettings JSONSettings { get; private set; }

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

            this.Account = new AccountCategory( this );
            this.Folder = new FolderCategory( this, this.Account );
            this.Task = new TaskCategory( this, this.Account );
            this.JSONSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
        }

        public async Task<string> SendPost( string action, string jsonData )
        {
            if ( this.Account.Token.IsNullOrEmpty() && action != "Sign in" )
            {
                throw new WAApiException( "Сначала авторизуйтесь!" );
            }
            this.LastJSONQuery = jsonData;
            if ( this.Queries > MaxQueries )
            {
                await TaskEx.Delay( RestTime );
                this.Queries = 0;
            }
            string url = "{0}/{1}/{2}".F( this._address, action, jsonData );
            string answer = this._webClient.DownloadString( url );
            this.LastJSONAnswer = answer;
            var baseAnswer = JsonConvert.DeserializeObject<BaseAnswer>( answer );
            if ( baseAnswer.Status != "Success" )
            {
                throw new WAApiException( "Ошибка запроса", jsonData, answer );
            }
            this.Queries++;
            return answer;
        }

        public async Task<string> SendPost( string action, object data )
        {
            string json = JsonConvert.SerializeObject( data, Formatting.None, this.JSONSettings );
            return await this.SendPost( action, json );
        }
    }
}