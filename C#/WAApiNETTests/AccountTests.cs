#region Using

using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WAApiNET;
using WAApiNET.Model;

#endregion

namespace WAApiNETTests
{
    [TestClass]
    public class AccountTests
    {
        private readonly string _email;
        private readonly string _password;
        private readonly WAApi _waApi;

        public AccountTests()
        {
            var content = File.ReadAllText( "loginInfo.txt" );
            string[] arr = content.Split( ';' );
            this._email = arr[ 0 ];
            this._password = arr[ 1 ];
            this._waApi = new WAApi( this._email, this._password );
        }

        [TestMethod]
        public async Task TestGeneralInfo()
        {
            await _waApi.Account.SignIn();
            await _waApi.Account.GetGeneralInfo();
            string login = _waApi.Account.CurrentAccount.Login;
            string email = _waApi.Account.CurrentAccount.Mail;
            string readOnlyKey = _waApi.Account.CurrentAccount.ReadonlyKey;
            int? balance = _waApi.Account.CurrentAccount.Balance;
            Assert.IsTrue( login == "testing" && email == "softezz_team@list.ru" &&
                           readOnlyKey == "sW/92PHdIAqgnBwX9I" && balance == 0 );
        }

        [TestMethod]
        public async Task TestReferrals()
        {
            await _waApi.Account.SignIn();
            Referral[] referrals = await _waApi.Account.GetReferrals();
            Assert.IsTrue( referrals.Length >= 0 );
        }
    }
}