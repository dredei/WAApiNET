#region Using

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WAApiNET;
using WAApiNET.Model;

#endregion

namespace WAApiNETTests
{
    [TestClass]
    public class FolderTests
    {
        private readonly WAApi _waApi;

        public FolderTests()
        {
            var getData = new GetData();
            string mail = getData.Mail;
            string password = getData.Password;
            this._waApi = new WAApi( mail, password );
        }

        [TestMethod]
        public async Task TestGetFolders()
        {
            await this._waApi.Account.SignIn();
            List<Folder> folders = await this._waApi.Folder.GetFolders();
            Assert.IsTrue( folders.Count >= 3 && folders[ 0 ].Name == "12" && folders[ 1 ].Name == "3" &&
                           folders[ 2 ].Name == "test" && folders[ 0 ].Tasks >= 5 &&
                           folders[ 1 ].Tasks >= 1 && folders[ 2 ].Tasks >= 0 );
        }
    }
}