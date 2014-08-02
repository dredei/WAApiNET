#region Using

using Newtonsoft.Json;
using WAApiNET.Model;

#endregion

namespace WAApiNET.ServerQueries
{
    internal class AddTaskQuery : WATask
    {
        public string Token { get; set; }
        [JsonProperty( PropertyName = "Folder ID" )]
        public int? FolderId { get; set; }

        public AddTaskQuery()
        {
            this.Token = null;
            this.FolderId = null;
        }

        public AddTaskQuery( int? folderId, string token, int? taskId, int? listId, int? afterClick, bool allowProxy,
            bool ignoreGu, double? growth, string domain, string profile, bool frozen, bool listMode, int? rangeSize,
            int? uniquePeriod, string name, string mask, int? days, string extSource, int? beforeClick,
            string profileSorage )
            : base( taskId, listId, afterClick, allowProxy, ignoreGu, growth, domain, profile, frozen, listMode,
                rangeSize, uniquePeriod, name, mask, days, extSource, beforeClick, profileSorage )
        {
            this.Token = token;
            this.FolderId = folderId;
        }

        public AddTaskQuery( int? folderId, string token, WATask task )
            : base( task )
        {
            this.Token = token;
            this.FolderId = folderId;
        }
    }
}