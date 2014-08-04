#region Using

using System.Threading.Tasks;
using Newtonsoft.Json;
using WAApiNET.Model;
using WAApiNET.Model.Account;
using WAApiNET.ServerAnswers;
using WAApiNET.ServerAnswers.Account;
using WAApiNET.ServerQueries;

#endregion

namespace WAApiNET.Categories
{
    /// <summary>
    /// Методы для работы с аккаунтом
    /// </summary>
    public class AccountCategory
    {
        private readonly WAApi _waApi;

        #region Поля

        /// <summary>
        /// Ссылка на текущий аккаунт (null, если не вызывался метод получения всех данных аккаунта)
        /// </summary>
        public WAAccount CurrentAccount { get; private set; }
        /// <summary>
        /// Сессионный токен
        /// </summary>
        public string Token { get; set; }

        #endregion

        /// <summary>
        /// Создает новый экземпляр
        /// </summary>
        /// <param name="waApi"></param>
        public AccountCategory( WAApi waApi )
        {
            this._waApi = waApi;
            this.Token = null;
            this.CurrentAccount = null;
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
        /// Завершение сессии
        /// </summary>
        /// <returns></returns>
        public async Task SignOut()
        {
            var signOutQ = new BaseQueryData( this.Token );
            await this._waApi.SendPost( "Sign out", signOutQ );
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
        public async Task<WAReferral[]> GetReferrals()
        {
            var getReferralsQ = new BaseQueryData( this.Token );
            string answer = await this._waApi.SendPost( "Get referrals", getReferralsQ );
            var getReferralsA = JsonConvert.DeserializeObject<GetReferralsAnswer>( answer );
            return getReferralsA.Data.Referrals.ToArray();
        }

        /// <summary>
        /// Получение всех данных аккаунта
        /// </summary>
        /// <returns></returns>
        public async Task<WAAllInfo> GetAll()
        {
            var getAllQ = new BaseQueryData( this.Token );
            string answer = await this._waApi.SendPost( "Get all", getAllQ );
            var getAllA = JsonConvert.DeserializeObject<GetAllAnswer>( answer );
            return getAllA.Data;
        }
    }
}