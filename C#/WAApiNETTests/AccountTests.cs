#region Using

using System.IO;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WAApiNET;

#endregion

namespace WAApiNETTests
{
    [TestClass]
    public class AccountTests
    {
        private readonly string _email;
        private readonly string _password;

        public AccountTests()
        {
            var content = File.ReadAllText( "loginInfo.txt" );
            string[] arr = content.Split( ';' );
            this._email = arr[ 0 ];
            this._password = arr[ 1 ];
        }

        [TestMethod]
        public async Task TestGeneralInfo()
        {
            var waapi = new WAApi( this._email, this._password );
            await waapi.Account.SignIn();
            await waapi.Account.GetGeneralInfo();
            string login = waapi.Account.CurrentAccount.Login;
            string email = waapi.Account.CurrentAccount.Mail;
            string readOnlyKey = waapi.Account.CurrentAccount.ReadonlyKey;
            int? balance = waapi.Account.CurrentAccount.Balance;
            Assert.IsTrue( login == "testing" && email == "softezz_team@list.ru" &&
                           readOnlyKey == "sW/92PHdIAqgnBwX9I" && balance == 0 );
        }
    }
}