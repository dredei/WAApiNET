#region Using

using System;
using System.Threading.Tasks;
using ExtensionMethods;
using Newtonsoft.Json;
using WAApiNET.Model;
using WAApiNET.ServerAnswers;
using WAApiNET.ServerQueries;

#endregion

namespace WAApiNET.Categories
{
    public class AccountCategory
    {
        private readonly WAApi _waApi;

        #region Поля

        public Account CurrentAccount { get; private set; }
        public string Token { get; set; }

        #endregion

        public AccountCategory( WAApi waApi )
        {
            this._waApi = waApi;
            this.Token = null;
        }

        /// <summary>
        /// Авторизация
        /// </summary>
        /// <param name="remember"></param>
        /// <returns></returns>
        public async Task SignIn( bool remember = false )
        {
            var signInQ = new SignInQuery( this._waApi.Email, this._waApi.Password );
            string answer = await this._waApi.SendPost( "Sign in", signInQ );
            var signInA = JsonConvert.DeserializeObject<SignInAnswer>( answer );
            this.Token = signInA.Data.Token;
        }

        /// <summary>
        /// Получение основных данных аккаунта
        /// </summary>
        /// <returns></returns>
        public async Task GetGeneralInfo()
        {
            if ( this.Token.IsNullOrEmpty() )
            {
                throw new Exception( "Сначала авторизуйтесь!" );
            }
            var getGeneralInfoQ = new BaseQueryData( this.Token );
            string answer = await this._waApi.SendPost( "Get general info", getGeneralInfoQ );
            var getGeneralInfoA = JsonConvert.DeserializeObject<GetGeneralInfoAnswer>( answer );
            this.CurrentAccount = getGeneralInfoA.Data;
        }
    }
}