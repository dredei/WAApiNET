#region Using

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WAApiNET.Exception;
using WAApiNET.Model.Folder;
using WAApiNET.Model.Task;
using WAApiNET.ServerAnswers.Task;
using WAApiNET.ServerQueries;
using WAApiNET.ServerQueries.Task;

#endregion

namespace WAApiNET.Categories
{
    /// <summary>
    /// Методы для работы с заданиями
    /// </summary>
    public class TaskCategory
    {
        private readonly WAApi _waApi;
        private readonly AccountCategory _accountCategory;

        /// <summary>
        /// Создает новый экземпляр
        /// </summary>
        /// <param name="waApi"></param>
        /// <param name="accountCategory"></param>
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
            string answer = await this._waApi.SendGet( "Get tasks", getTasksQ );
            var getTasksA = JsonConvert.DeserializeObject<GetTasksAnswer>( answer );
            return getTasksA.Data.Tasks;
        }

        /// <summary>
        /// Получение заданий
        /// </summary>
        /// <param name="folder">Папка</param>
        /// <returns></returns>
        public async Task<List<WATask>> GetTasks( WAFolder folder )
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
            string answer = await this._waApi.SendGet( "Add task", addTasksQ );
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
            await this._waApi.SendGet( "Delete tasks", deleteTaskQ );
        }

        /// <summary>
        /// Удаление заданий
        /// </summary>
        /// <param name="folder">Папка</param>
        /// <param name="tasks">Массив заданий</param>
        /// <returns></returns>
        public async Task DeleteTasks( WAFolder folder, IEnumerable<WATask> tasks )
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
        public async Task<List<WADayTargetingExtend>> GetDaysStats( int folderId, int taskId )
        {
            var getDaysStatsQ = new FolderTaskQuery( this._accountCategory.Token, folderId, taskId );
            string answer = await this._waApi.SendGet( "Get days stats", getDaysStatsQ );
            var getDaysStatsA = JsonConvert.DeserializeObject<GetDaysStatsAnswer>( answer );
            return getDaysStatsA.Data.DayTargeting;
        }

        /// <summary>
        /// Получение суточной статистики
        /// </summary>
        /// <param name="folder">Папка</param>
        /// <param name="task">Задание</param>
        /// <returns></returns>
        public async Task<List<WADayTargetingExtend>> GetDaysStats( WAFolder folder, WATask task )
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
        public async Task<List<WATimeDistribution>> GetTimeDistribution( int folderId, int taskId )
        {
            var getTimeDistributionQ = new FolderTaskQuery( this._accountCategory.Token, folderId, taskId );
            string answer = await this._waApi.SendGet( "Get time distribution", getTimeDistributionQ );
            var getTimeDistributionA = JsonConvert.DeserializeObject<GetTimeDistributionAnswer>( answer );
            return getTimeDistributionA.Data.TimeDistribution;
        }

        /// <summary>
        /// Получение временного распределения
        /// </summary>
        /// <param name="folder">Папка</param>
        /// <param name="task">Задание</param>
        /// <returns></returns>
        public async Task<List<WATimeDistribution>> GetTimeDistribution( WAFolder folder, WATask task )
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
        public async Task<List<WAGeoTargeting>> GetGeoTargeting( int folderId, int taskId )
        {
            var getGeoTargetingQ = new FolderTaskQuery( this._accountCategory.Token, folderId, taskId );
            string answer = await this._waApi.SendGet( "Get geo targeting", getGeoTargetingQ );
            var getGeoTargetingA = JsonConvert.DeserializeObject<GetGeoTargetingAnswer>( answer );
            return getGeoTargetingA.Data.GeoTargeting;
        }

        /// <summary>
        /// Получение геотаргетинга
        /// </summary>
        /// <param name="folder">Папка</param>
        /// <param name="task">Задание</param>
        /// <returns></returns>
        public async Task<List<WAGeoTargeting>> GetGeoTargeting( WAFolder folder, WATask task )
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
        public async Task<List<WAWeekTargeting>> GetWeekTargeting( int folderId, int taskId )
        {
            var getWeekTargetingQ = new FolderTaskQuery( this._accountCategory.Token, folderId, taskId );
            string answer = await this._waApi.SendGet( "Get week targeting", getWeekTargetingQ );
            var getWeekTargetingA = JsonConvert.DeserializeObject<GetWeekTargetingAnswer>( answer );
            return getWeekTargetingA.Data.WeekTargeting;
        }

        /// <summary>
        /// Получение недельного таргетинга
        /// </summary>
        /// <param name="folder">Папка</param>
        /// <param name="task">Задание</param>
        /// <returns></returns>
        public async Task<List<WAWeekTargeting>> GetWeekTargeting( WAFolder folder, WATask task )
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

        /// <summary>
        /// Получение суточного таргетинга
        /// </summary>
        /// <param name="folderId">Id папки</param>
        /// <param name="taskId">Id задания</param>
        /// <returns></returns>
        public async Task<List<WADayTargeting>> GetDayTargeting( int folderId, int taskId )
        {
            var getDayTargetingQ = new FolderTaskQuery( this._accountCategory.Token, folderId, taskId );
            string answer = await this._waApi.SendGet( "Get day targeting", getDayTargetingQ );
            var getDayTargetingA = JsonConvert.DeserializeObject<GetDayTargetingAnswer>( answer );
            return getDayTargetingA.Data.DayTargeting;
        }

        /// <summary>
        /// Получение суточного таргетинга
        /// </summary>
        /// <param name="folder">Папка</param>
        /// <param name="task">Задание</param>
        /// <returns></returns>
        public async Task<List<WADayTargeting>> GetDayTargeting( WAFolder folder, WATask task )
        {
            if ( folder == null || folder.FolderId == null )
            {
                throw new WAApiException( "Некорректный параметр: folder!" );
            }
            if ( task == null || task.TaskId == null )
            {
                throw new WAApiException( "Некорректный параметр: task!" );
            }
            return await this.GetDayTargeting( (int)folder.FolderId, (int)task.TaskId );
        }

        /// <summary>
        /// Получение всех данных задания
        /// </summary>
        /// <param name="folderId">Id папки</param>
        /// <param name="taskId">Id задания</param>
        /// <returns></returns>
        public async Task<WATaskWhole> GetWholeTask( int folderId, int taskId )
        {
            var getWholeTaskQ = new FolderTaskQuery( this._accountCategory.Token, folderId, taskId );
            string answer = await this._waApi.SendGet( "Get whole task", getWholeTaskQ );
            var getWholeTaskA = JsonConvert.DeserializeObject<GetWholeTaskAnswer>( answer );
            return getWholeTaskA.Data.Task;
        }

        /// <summary>
        /// Получение всех данных задания
        /// </summary>
        /// <param name="folder">Папка</param>
        /// <param name="task">Задание</param>
        /// <returns></returns>
        public async Task<WATaskWhole> GetWholeTask( WAFolder folder, WATask task )
        {
            if ( folder == null || folder.FolderId == null )
            {
                throw new WAApiException( "Некорректный параметр: folder!" );
            }
            if ( task == null || task.TaskId == null )
            {
                throw new WAApiException( "Некорректный параметр: task!" );
            }
            return await this.GetWholeTask( (int)folder.FolderId, (int)task.TaskId );
        }

        /// <summary>
        /// Изменение настроек заданий
        /// </summary>
        /// <param name="folderId">Id папки</param>
        /// <param name="taskParams">Настройки заданий</param>
        /// <param name="taskIds">Массив id заданий</param>
        /// <returns></returns>
        public async Task SetTasksParams( int folderId, WATaskWhole taskParams, int[] taskIds )
        {
            if ( taskParams == null )
            {
                throw new WAApiException( "Некорректный параметр: taskParams!" );
            }
            var setTasksParamsQ = new SetTasksParamsQuery( this._accountCategory.Token, folderId, taskIds, taskParams );
            await this._waApi.SendGet( "Set tasks params", setTasksParamsQ );
        }

        /// <summary>
        /// Изменение настроек заданий
        /// </summary>
        /// <param name="folder">Папка</param>
        /// <param name="taskParams">Настройки заданий</param>
        /// <param name="tasks">Задания</param>
        /// <returns></returns>
        public async Task SetTasksParams( WAFolder folder, WATaskWhole taskParams, WATask[] tasks )
        {
            if ( taskParams == null )
            {
                throw new WAApiException( "Некорректный параметр: taskParams!" );
            }
            if ( folder == null || folder.FolderId == null )
            {
                throw new WAApiException( "Некорректный параметр: folder" );
            }
            await
                this.SetTasksParams( (int)folder.FolderId, taskParams,
                    tasks.Select( t => t.TaskId != null ? (int)t.TaskId : 0 ).ToArray() );
        }

        /// <summary>
        /// Копирование настроек задания
        /// </summary>
        /// <param name="sourceFolderId">Исходный Id папки</param>
        /// <param name="sourceTaskId">Исходный Id заданий</param>
        /// <param name="targetFolderId">Id папки назначения</param>
        /// <param name="targetTasksIds">Массив id заданий назначения</param>
        /// <param name="taskSettings">Настройки</param>
        /// <returns></returns>
        public async Task CopyTaskSettings( int sourceFolderId, int sourceTaskId, int targetFolderId,
            int[] targetTasksIds,
            WATaskWhole taskSettings )
        {
            var copyTaskSettingsQ = new CopyTaskSettingsQuery( this._accountCategory.Token, sourceFolderId, sourceTaskId,
                targetFolderId, targetTasksIds, taskSettings );
            await this._waApi.SendGet( "Copy task settings", copyTaskSettingsQ );
        }

        /// <summary>
        /// Копирование настроек задания
        /// </summary>
        /// <param name="sourceFolder">Исходная папка</param>
        /// <param name="sourceTask">Исходное задание</param>
        /// <param name="targetFolder">Папка назначения</param>
        /// <param name="targetTasks">Задания назначения</param>
        /// <param name="taskSettings">Настройки</param>
        /// <returns></returns>
        public async Task CopyTaskSettings( WAFolder sourceFolder, WATask sourceTask, WAFolder targetFolder,
            IEnumerable<WATask> targetTasks, WATaskWhole taskSettings )
        {
            if ( sourceFolder == null || sourceFolder.FolderId == null )
            {
                throw new WAApiException( "Некорректный параметр: sourceFolder!" );
            }
            if ( sourceTask == null || sourceTask.TaskId == null )
            {
                throw new WAApiException( "Некорректный параметр: sourceTask!" );
            }
            if ( targetFolder == null || targetFolder.FolderId == null )
            {
                throw new WAApiException( "Некорректный параметр: sourceFolder!" );
            }
            await
                this.CopyTaskSettings( (int)sourceFolder.FolderId, (int)sourceTask.TaskId, (int)targetFolder.FolderId,
                    targetTasks.Select( t => t.TaskId != null ? (int)t.TaskId : 0 ).ToArray(), taskSettings );
        }

        /// <summary>
        /// Перенос заданий в другую папку
        /// </summary>
        /// <param name="sourceFolderId">Id исходной папки</param>
        /// <param name="targetFolderId">Id папки назначения</param>
        /// <param name="taskIds">Массив id заданий</param>
        /// <returns></returns>
        public async Task MoveTasks( int sourceFolderId, int targetFolderId, int[] taskIds )
        {
            var copyTaskSettingsQ = new MoveTasksQuery( this._accountCategory.Token, sourceFolderId, targetFolderId,
                taskIds );
            await this._waApi.SendGet( "Move tasks", copyTaskSettingsQ );
        }

        /// <summary>
        /// Перенос заданий в другую папку
        /// </summary>
        /// <param name="sourceFolder">Исходная папка</param>
        /// <param name="targetFolder">Папка назначения</param>
        /// <param name="taskIds">Массив id заданий</param>
        /// <returns></returns>
        public async Task MoveTasks( WAFolder sourceFolder, WAFolder targetFolder, int[] taskIds )
        {
            if ( sourceFolder == null || sourceFolder.FolderId == null )
            {
                throw new WAApiException( "Некорректный параметр: sourceFolder!" );
            }
            if ( targetFolder == null || targetFolder.FolderId == null )
            {
                throw new WAApiException( "Некорректный параметр: sourceFolder!" );
            }
            await this.MoveTasks( (int)sourceFolder.FolderId, (int)targetFolder.FolderId, taskIds );
        }

        /// <summary>
        /// Клонирование задания
        /// </summary>
        /// <param name="sourceFolderId">Id исходной папки</param>
        /// <param name="targetFolderId">Id папки назначения</param>
        /// <param name="taskId">Id задания</param>
        /// <param name="name">Имя нового задания</param>
        /// <returns></returns>
        public async Task CloneTask( int sourceFolderId, int targetFolderId, int taskId, string name )
        {
            var copyTaskSettingsQ = new CloneTaskQuery( this._accountCategory.Token, sourceFolderId, targetFolderId,
                taskId, name );
            await this._waApi.SendGet( "Clone task", copyTaskSettingsQ );
        }

        /// <summary>
        /// Клонирование задания
        /// </summary>
        /// <param name="sourceFolder">Исходная папка</param>
        /// <param name="targetFolder">Папка назначения</param>
        /// <param name="task">Задание</param>
        /// <param name="name">Имя нового задания</param>
        /// <returns></returns>
        public async Task CloneTask( WAFolder sourceFolder, WAFolder targetFolder, WATask task, string name )
        {
            if ( sourceFolder == null || sourceFolder.FolderId == null )
            {
                throw new WAApiException( "Некорректный параметр: sourceFolder!" );
            }
            if ( targetFolder == null || targetFolder.FolderId == null )
            {
                throw new WAApiException( "Некорректный параметр: sourceFolder!" );
            }
            if ( task.TaskId == null )
            {
                throw new WAApiException( "Некорректный параметр: task!" );
            }
            await this.CloneTask( (int)sourceFolder.FolderId, (int)targetFolder.FolderId, (int)task.TaskId, name );
        }
    }
}