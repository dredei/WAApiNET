#region Using

using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WAApiNET;
using WAApiNET.Model.Account;

#endregion

namespace WAApiNETTests
{
    [TestClass]
    public class AccountTests
    {
        private readonly WAApi _waApi;

        public AccountTests()
        {
            var getData = new GetData();
            string mail = getData.Mail;
            string password = getData.Password;
            this._waApi = new WAApi( mail, password );
        }

        [TestMethod]
        public async Task TestGeneralInfo()
        {
            await this._waApi.Account.SignIn();
            await this._waApi.Account.GetGeneralInfo();
            string login = this._waApi.Account.CurrentAccount.Login;
            string email = this._waApi.Account.CurrentAccount.Mail;
            string readOnlyKey = this._waApi.Account.CurrentAccount.ReadonlyKey;
            int? balance = this._waApi.Account.CurrentAccount.Balance;
            Assert.IsTrue( login == "testing" && email == "softezz_team@list.ru" &&
                           readOnlyKey == "sW/92PHdIAqgnBwX9I" && balance == 0 );
        }

        [TestMethod]
        public async Task TestReferrals()
        {
            await this._waApi.Account.SignIn();
            WAReferral[] referrals = await this._waApi.Account.GetReferrals();
            Assert.IsTrue( referrals.Length >= 0 );
        }
    }
}