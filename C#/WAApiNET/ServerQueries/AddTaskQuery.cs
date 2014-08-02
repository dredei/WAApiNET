#region Using

using WAApiNET.Model;

#endregion

namespace WAApiNET.ServerQueries
{
    internal class AddTaskQuery : WATask
    {
        public string Token { get; set; }

        public AddTaskQuery()
        {
            this.Token = null;
        }

        public AddTaskQuery( string token, int? taskId, int? listId, int? afterClick, bool allowProxy, bool ignoreGu,
            double? growth,
            string domain, string profile, bool frozen, bool listMode, int? rangeSize, int? uniquePeriod, string name,
            string mask, int? days, string extSource, int? beforeClick, string profileSorage )
            : base( taskId, listId, afterClick, allowProxy, ignoreGu, growth, domain, profile, frozen, listMode,
                rangeSize, uniquePeriod, name, mask, days, extSource, beforeClick, profileSorage )
        {
            this.Token = token;
        }

        public AddTaskQuery( string token, WATask task )
            : base( task )
        {
            this.Token = token;
        }
    }
}