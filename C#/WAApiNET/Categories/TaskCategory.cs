#region Using

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WAApiNET.Exception;
using WAApiNET.Model;
using WAApiNET.ServerAnswers;
using WAApiNET.ServerQueries;

#endregion

namespace WAApiNET.Categories
{
    public class TaskCategory
    {
        private readonly WAApi _waApi;
        private readonly AccountCategory _accountCategory;

        public TaskCategory( WAApi waApi, AccountCategory accountCategory )
        {
            this._waApi = waApi;
            this._accountCategory = accountCategory;
        }

        /// <summary>
        /// Получение заданий
        /// </summary>
        /// <param name="folderId">Id папки</param>
        /// <returns></returns>
        public async Task<List<WATask>> GetTasks( int folderId )
        {
            var getTasksQ = new GetTasksQuery( this._accountCategory.Token, folderId );
            string answer = await this._waApi.SendPost( "Get tasks", getTasksQ );
            var getTasksA = JsonConvert.DeserializeObject<GetTasksAnswer>( answer );
            return getTasksA.Data.Tasks;
        }

        /// <summary>
        /// Получение заданий
        /// </summary>
        /// <param name="folder">Папка</param>
        /// <returns></returns>
        public async Task<List<WATask>> GetTasks( Folder folder )
        {
            if ( folder == null || folder.FolderId == null )
            {
                throw new WAApiException( "Некорректный параметр: folder!" );
            }
            return await this.GetTasks( (int)folder.FolderId );
        }

        /// <summary>
        /// Добавление задания
        /// </summary>
        /// <param name="folderId">Id папки</param>
        /// <param name="task">Задание</param>
        /// <returns></returns>
        public async Task<WATask> AddTask( int folderId, WATask task )
        {
            if ( task == null )
            {
                throw new WAApiException( "Некорректный параметр: task!" );
            }
            var addTasksQ = new AddTaskQuery( folderId, this._accountCategory.Token, task );
            string answer = await this._waApi.SendPost( "Add task", addTasksQ );
            var addTasksA = JsonConvert.DeserializeObject<AddTaskAnswer>( answer );
            return new WATask( task ) { TaskId = addTasksA.Data.TaskId };
        }

        /// <summary>
        /// Удаление заданий
        /// </summary>
        /// <param name="folderId">Id папки</param>
        /// <param name="taskIds">Массив id заданий</param>
        /// <returns></returns>
        public async Task DeleteTasks( int folderId, int[] taskIds )
        {
            if ( taskIds == null )
            {
                throw new WAApiException( "Некорректный параметр: taskIds!" );
            }
            var deleteTaskQ = new DeleteTasksQuery( this._accountCategory.Token, folderId, taskIds );
            await this._waApi.SendPost( "Delete tasks", deleteTaskQ );
        }

        /// <summary>
        /// Удаление заданий
        /// </summary>
        /// <param name="folder">Папка</param>
        /// <param name="tasks">Массив заданий</param>
        /// <returns></returns>
        public async Task DeleteTasks( Folder folder, IEnumerable<WATask> tasks )
        {
            if ( folder == null || folder.FolderId == null )
            {
                throw new WAApiException( "Некорректный параметр: folder!" );
            }
            if ( tasks == null )
            {
                throw new WAApiException( "Некорректный параметр: folder!" );
            }
            await
                this.DeleteTasks( (int)folder.FolderId,
                    tasks.Select( f => f.TaskId != null ? (int)f.TaskId : 0 ).ToArray() );
        }

        /// <summary>
        /// Получение суточной статистики
        /// </summary>
        /// <param name="folderId">Id папки</param>
        /// <param name="taskId">Id задания</param>
        /// <returns></returns>
        public async Task<DayTargeting[]> GetDaysStats( int folderId, int taskId )
        {
            var getDaysStatsQ = new FolderTaskQuery( this._accountCategory.Token, folderId, taskId );
            string answer = await this._waApi.SendPost( "Get days stats", getDaysStatsQ );
            var getDaysStatsA = JsonConvert.DeserializeObject<GetDaysStatsAnswer>( answer );
            return getDaysStatsA.Data.DayTargeting.ToArray();
        }

        /// <summary>
        /// Получение суточной статистики
        /// </summary>
        /// <param name="folder">Папка</param>
        /// <param name="task">Задание</param>
        /// <returns></returns>
        public async Task<DayTargeting[]> GetDaysStats( Folder folder, WATask task )
        {
            if ( folder == null || folder.FolderId == null )
            {
                throw new WAApiException( "Некорректный параметр: folder!" );
            }
            if ( task == null || task.TaskId == null )
            {
                throw new WAApiException( "Неккоректный параметр: task!" );
            }
            return await this.GetDaysStats( (int)folder.FolderId, (int)task.TaskId );
        }

        /// <summary>
        /// Получение временного распределения
        /// </summary>
        /// <param name="folderId">Id папки</param>
        /// <param name="taskId">Id задания</param>
        /// <returns></returns>
        public async Task<List<TimeDistribution>> GetTimeDistribution( int folderId, int taskId )
        {
            var getTimeDistributionQ = new FolderTaskQuery( this._accountCategory.Token, folderId, taskId );
            string answer = await this._waApi.SendPost( "Get time distribution", getTimeDistributionQ );
            var getTimeDistributionA = JsonConvert.DeserializeObject<GetTimeDistributionAnswer>( answer );
            return getTimeDistributionA.Data.TimeDistribution;
        }

        /// <summary>
        /// Получение временного распределения
        /// </summary>
        /// <param name="folder">Папка</param>
        /// <param name="task">Задание</param>
        /// <returns></returns>
        public async Task<List<TimeDistribution>> GetTimeDistribution( Folder folder, WATask task )
        {
            if ( folder == null || folder.FolderId == null )
            {
                throw new WAApiException( "Некорректный параметр: folder!" );
            }
            if ( task == null || task.TaskId == null )
            {
                throw new WAApiException( "Некорректный параметр: task!" );
            }
            return await this.GetTimeDistribution( (int)folder.FolderId, (int)task.TaskId );
        }

        /// <summary>
        /// Получение геотаргетинга
        /// </summary>
        /// <param name="folderId">Id папки</param>
        /// <param name="taskId">Id задания</param>
        /// <returns></returns>
        public async Task<List<GeoTargeting>> GetGeoTargeting( int folderId, int taskId )
        {
            var getGeoTargetingQ = new FolderTaskQuery( this._accountCategory.Token, folderId, taskId );
            string answer = await this._waApi.SendPost( "Get geo targeting", getGeoTargetingQ );
            var getGeoTargetingA = JsonConvert.DeserializeObject<GetGeoTargetingAnswer>( answer );
            return getGeoTargetingA.Data.GeoTargeting;
        }

        /// <summary>
        /// Получение геотаргетинга
        /// </summary>
        /// <param name="folder">Папка</param>
        /// <param name="task">Задание</param>
        /// <returns></returns>
        public async Task<List<GeoTargeting>> GetGeoTargeting( Folder folder, WATask task )
        {
            if ( folder == null || folder.FolderId == null )
            {
                throw new WAApiException( "Некорректный параметр: folder!" );
            }
            if ( task == null || task.TaskId == null )
            {
                throw new WAApiException( "Некорректный параметр: task!" );
            }
            return await this.GetGeoTargeting( (int)folder.FolderId, (int)task.TaskId );
        }

        /// <summary>
        /// Получение недельного таргетинга
        /// </summary>
        /// <param name="folderId">Id папки</param>
        /// <param name="taskId">Id задания</param>
        /// <returns></returns>
        public async Task<List<WeekTargeting>> GetWeekTargeting( int folderId, int taskId )
        {
            var getWeekTargetingQ = new FolderTaskQuery( this._accountCategory.Token, folderId, taskId );
            string answer = await this._waApi.SendPost( "Get week targeting", getWeekTargetingQ );
            var getWeekTargetingA = JsonConvert.DeserializeObject<GetWeekTargetingAnswer>( answer );
            return getWeekTargetingA.Data.WeekTargeting;
        }

        /// <summary>
        /// Получение недельного таргетинга
        /// </summary>
        /// <param name="folder">Папка</param>
        /// <param name="task">Задание</param>
        /// <returns></returns>
        public async Task<List<WeekTargeting>> GetWeekTargeting( Folder folder, WATask task )
        {
            if ( folder == null || folder.FolderId == null )
            {
                throw new WAApiException( "Некорректный параметр: folder!" );
            }
            if ( task == null || task.TaskId == null )
            {
                throw new WAApiException( "Некорректный параметр: task!" );
            }
            return await this.GetWeekTargeting( (int)folder.FolderId, (int)task.TaskId );
        }
    }
}