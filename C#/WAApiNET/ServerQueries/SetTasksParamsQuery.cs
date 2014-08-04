#region Using

using Newtonsoft.Json;
using WAApiNET.Model;

#endregion

namespace WAApiNET.ServerQueries
{
    internal class SetTasksParamsQuery : WATaskWhole
    {
        public string Token { get; set; }

        [JsonProperty( PropertyName = "Folder ID" )]
        public int? FolderId { get; set; }

        [JsonProperty( PropertyName = "Task IDs" )]
        public int[] TaskIds { get; set; }

        public SetTasksParamsQuery()
        {
            this.Token = null;
            this.FolderId = null;
            this.TaskIds = null;
        }

        public SetTasksParamsQuery( string token, int? folderId, int[] taskIds, WATaskWhole task )
            : base( task, task.GeoTargeting, task.DayTargeting, task.DayStats, task.WeekTargeting,
                task.TimeDistribution )
        {
            this.Token = token;
            this.FolderId = folderId;
            this.TaskIds = taskIds;
        }
    }
}