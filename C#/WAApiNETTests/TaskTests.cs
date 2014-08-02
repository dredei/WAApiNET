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
    public class TaskTests
    {
        private readonly WAApi _waApi;

        public TaskTests()
        {
            var getData = new GetData();
            string mail = getData.Mail;
            string password = getData.Password;
            this._waApi = new WAApi( mail, password );
        }

        [TestMethod]
        public async Task TestAddDeleteTask()
        {
            await this._waApi.Account.SignIn();
            var task = new WATask( null, 0, 0, false, false, 0, "softez.pp.ua", "", true, false, 10, 1440,
                "TaskFromTest", "", 0, "http://softez.pp.ua/1", 100, "" );
            task = await this._waApi.Task.AddTask( 1, task );
            List<Folder> folders = await this._waApi.Folder.GetFolders();
            int tasksCountAfterAdd = (int)folders[ 0 ].Tasks;
            await this._waApi.Task.DeleteTasks( folders[ 0 ], new[] { task } );
            folders = await this._waApi.Folder.GetFolders();
            Assert.IsTrue( tasksCountAfterAdd == 6 && folders[ 0 ].Tasks == 5 );
        }
    }
}