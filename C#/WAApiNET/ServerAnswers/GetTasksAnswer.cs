#region Using

using System.Collections.Generic;
using WAApiNET.Model;

#endregion

namespace WAApiNET.ServerAnswers
{
    internal class GetTasksAnswer : BaseAnswer
    {
        internal class DataObj
        {
            public List<WATask> Tasks { get; set; }

            public DataObj()
            {
                this.Tasks = new List<WATask>();
            }
        }

        public DataObj Data { get; set; }

        public GetTasksAnswer()
        {
            this.Data = new DataObj();
        }
    }
}