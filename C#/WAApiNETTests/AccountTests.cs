#region Using

using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WAApiNET;

#endregion

namespace WAApiNETTests
{
    [TestClass]
    public class AccountTests
    {
        [TestMethod]
        public async Task TestGeneralInfo()
        {
            var waapi = new WAApi( "softezz_team@list.ru", "UuBC9zI0S0RNZH-k" );
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