#region Using

using Newtonsoft.Json;

#endregion

namespace WAApiNET.ServerAnswers.Task
{
    internal class AddTaskAnswer : BaseAnswer
    {
        internal class DataObj
        {
            [JsonProperty( PropertyName = "Task ID" )]
            public int? TaskId { get; set; }
        }

        public DataObj Data { get; set; }
    }
}