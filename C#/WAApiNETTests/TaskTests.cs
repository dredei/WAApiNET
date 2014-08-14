#region Using

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WAApiNET;
using WAApiNET.Model.Task;

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
        public async Task TestGetTimeDistribution()
        {
            await this._waApi.Account.SignIn();
            List<WATimeDistribution> timeDistribution = await this._waApi.Task.GetTimeDistribution( 1, 1 );
            Assert.IsTrue( timeDistribution[ 0 ].Priority == 6 && timeDistribution[ 1 ].Priority == 5 &&
                           timeDistribution[ 2 ].Priority == 5 && timeDistribution[ 3 ].Priority == 6 );
        }

        [TestMethod]
        public async Task TestGetGeoTargeting()
        {
            await this._waApi.Account.SignIn();
            List<WAGeoTargeting> geoTargeting = await this._waApi.Task.GetGeoTargeting( 1, 1 );
            Assert.IsTrue( geoTargeting.FirstOrDefault( gt => gt.ZoneId == 18 ).Target == 100 &&
                           geoTargeting.FirstOrDefault( gt => gt.ZoneId == 19 ).Target == 50 );
        }

        [TestMethod]
        public async Task TestGetWeekTargeting()
        {
            await this._waApi.Account.SignIn();
            List<WAWeekTargeting> weekTargeting = await this._waApi.Task.GetWeekTargeting( 1, 1 );
            Assert.IsTrue( weekTargeting[ 0 ].Target == 59.38 && weekTargeting[ 1 ].Target == 58.04 &&
                           weekTargeting[ 2 ].Target == 46.88 );
        }

        [TestMethod]
        public async Task TestGetDayTargeting()
        {
            await this._waApi.Account.SignIn();
            List<WADayTargeting> dayTargeting = await this._waApi.Task.GetDayTargeting( 1, 1 );
            Assert.IsTrue( dayTargeting[ 0 ].Max == 9 && dayTargeting[ 0 ].Min == 3 && dayTargeting[ 1 ].Max == 12 &&
                           dayTargeting[ 1 ].Min == 3 && dayTargeting[ 2 ].Max == 9 && dayTargeting[ 2 ].Min == 4 );
        }

        [TestMethod]
        public async Task TestGetWholeTask()
        {
            await this._waApi.Account.SignIn();
            WATaskWhole wholeTask = await this._waApi.Task.GetWholeTask( 1, 1 );
            List<WATimeDistribution> timeDistribution = wholeTask.TimeDistribution;
            List<WAGeoTargeting> geoTargeting = wholeTask.GeoTargeting;
            List<WAWeekTargeting> weekTargeting = wholeTask.WeekTargeting;
            List<WADayTargeting> dayTargeting = wholeTask.DayTargeting;
            Assert.IsTrue( timeDistribution[ 0 ].Priority == 6 && timeDistribution[ 1 ].Priority == 5 &&
                           timeDistribution[ 2 ].Priority == 5 && timeDistribution[ 3 ].Priority == 6 &&
                           geoTargeting.FirstOrDefault( gt => gt.ZoneId == 18 ).Target == 100 &&
                           geoTargeting.FirstOrDefault( gt => gt.ZoneId == 19 ).Target == 50 &&
                           weekTargeting[ 0 ].Target == 59.38 && weekTargeting[ 1 ].Target == 58.04 &&
                           weekTargeting[ 2 ].Target == 46.88 &&
                           dayTargeting[ 0 ].Max == 9 && dayTargeting[ 0 ].Min == 3 && dayTargeting[ 1 ].Max == 12 &&
                           dayTargeting[ 1 ].Min == 3 && dayTargeting[ 2 ].Max == 9 && dayTargeting[ 2 ].Min == 4 );
        }

        [TestMethod]
        public async Task TestSetTasksParams()
        {
            await this._waApi.Account.SignIn();
            const int folderId = 1;
            var task = new WATask( null, 0, 0, false, false, 0, "softez.pp.ua", "", true, false, 10, 1440,
                "TaskFromTest", "", 0, "http://softez.pp.ua/1", 100, "" );
            task = await this._waApi.Task.AddTask( folderId, task );
            var newTask = new WATaskWhole
            {
                ExtSource = "http://softez.pp.ua/2",
                AfterClick = 35,
                Mask = "mask",
                DayTargeting = new List<WADayTargeting>( new[]
                {
                    new WADayTargeting( 5, 10, 0 ),
                    new WADayTargeting( 6, 11, 1 )
                } ),
                WeekTargeting = new List<WAWeekTargeting>( new[]
                {
                    new WAWeekTargeting( 0, 35 ),
                    new WAWeekTargeting( 1, 45.5 )
                } )
            };
            if ( task.TaskId == null )
            {
                Assert.Fail();
            }
            await this._waApi.Task.SetTaskParams( folderId, newTask, (int)task.TaskId );
            newTask = await this._waApi.Task.GetWholeTask( folderId, (int)task.TaskId );
            string extSource = newTask.ExtSource;
            int? afterClick = newTask.AfterClick;
            await this._waApi.Task.DeleteTask( folderId, (int)task.TaskId );
            Assert.IsTrue( extSource == "http://softez.pp.ua/2" && afterClick == 35 &&
                           newTask.DayTargeting.Any( dt => dt.Hour == 0 && dt.Min == 5 && dt.Max == 10 ) &&
                           newTask.DayTargeting.Any( dt => dt.Hour == 1 && dt.Min == 6 && dt.Max == 11 ) &&
                           newTask.WeekTargeting.Any( wt => wt.Day == 0 && wt.Target == 35 ) &&
                           newTask.WeekTargeting.Any( wt => wt.Day == 1 && wt.Target == 45.5 ) );
        }
    }
}