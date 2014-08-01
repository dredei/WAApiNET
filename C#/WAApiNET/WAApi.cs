#region Using

using System.Net;
using System.Text;
using System.Threading.Tasks;
using ExtensionMethods;
using Newtonsoft.Json;
using WAApiNET.Categories;

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
        public int Queries { get; private set; }
        public string LastJSONQuery { get; private set; }
        public string LastJSONAnswer { get; private set; }

        #endregion

        /// <summary>
        /// Создает новый экземпляр объекта WAApi с авторизацией
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="remember"></param>
        /// <param name="address"></param>
        public WAApi( string email, string password, bool remember = false, string address = "http://api.waspace.net" )
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
        }

        public async Task<string> SendPost( string action, string jsonData )
        {
            this.LastJSONQuery = jsonData;
            if ( this.Queries > MaxQueries )
            {
                await TaskEx.Delay( RestTime );
                this.Queries = 0;
            }
            string answer = this._webClient.DownloadString( "{0}/{1}/{2}".F( this._address, action, jsonData ) );
            this.Queries++;
            return answer;
        }

        public async Task<string> SendPost( string action, object data )
        {
            string json = JsonConvert.SerializeObject( data );
            return await this.SendPost( action, json );
        }
    }
}