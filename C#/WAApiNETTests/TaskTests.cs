#region Using

using System.Collections.Generic;
using System.Linq;
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

        [TestMethod]
        public async Task TestGetTimeDistribution()
        {
            await this._waApi.Account.SignIn();
            List<TimeDistribution> timeDistribution = await this._waApi.Task.GetTimeDistribution( 1, 1 );
            Assert.IsTrue( timeDistribution[ 0 ].Priority == 6 && timeDistribution[ 1 ].Priority == 5 &&
                           timeDistribution[ 2 ].Priority == 5 && timeDistribution[ 3 ].Priority == 6 );
        }

        [TestMethod]
        public async Task TestGetGeoTargeting()
        {
            await this._waApi.Account.SignIn();
            List<GeoTargeting> geoTargeting = await this._waApi.Task.GetGeoTargeting( 1, 1 );
            Assert.IsTrue( geoTargeting.FirstOrDefault( gt => gt.Name == "UA" ).Target == 100 &&
                           geoTargeting.FirstOrDefault( gt => gt.Name == "RU" ).Target == 50 );
        }

        [TestMethod]
        public async Task TestGetWeekTargeting()
        {
            await this._waApi.Account.SignIn();
            List<WeekTargeting> weekTargeting = await this._waApi.Task.GetWeekTargeting( 1, 1 );
            Assert.IsTrue( weekTargeting[ 0 ].Target == 59.38 && weekTargeting[ 1 ].Target == 58.04 &&
                           weekTargeting[ 2 ].Target == 46.88 );
        }

        [TestMethod]
        public async Task TestGetDayTargeting()
        {
            await this._waApi.Account.SignIn();
            List<DayTargeting> dayTargeting = await this._waApi.Task.GetDayTargeting( 1, 1 );
            Assert.IsTrue( dayTargeting[ 0 ].Max == 9 && dayTargeting[ 0 ].Min == 3 && dayTargeting[ 1 ].Max == 12 &&
                           dayTargeting[ 1 ].Min == 3 && dayTargeting[ 2 ].Max == 9 && dayTargeting[ 2 ].Min == 4 );
        }
    }
}