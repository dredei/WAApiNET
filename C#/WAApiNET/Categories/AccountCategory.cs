#region Using

using System.Threading.Tasks;
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
        /// <returns></returns>
        public async Task SignIn()
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
            var getGeneralInfoQ = new BaseQueryData( this.Token );
            string answer = await this._waApi.SendPost( "Get general info", getGeneralInfoQ );
            var getGeneralInfoA = JsonConvert.DeserializeObject<GetGeneralInfoAnswer>( answer );
            this.CurrentAccount = getGeneralInfoA.Data;
        }

        /// <summary>
        /// Получение рефералов
        /// </summary>
        /// <returns></returns>
        public async Task<Referral[]> GetReferrals()
        {
            var getReferralsQ = new BaseQueryData( this.Token );
            string answer = await this._waApi.SendPost( "Get referrals", getReferralsQ );
            var getReferralsA = JsonConvert.DeserializeObject<GetReferralsAnswer>( answer );
            return getReferralsA.Data.Referrals.ToArray();
        }
    }
}