#region Using

using WAApiNET.Model.Task;

#endregion

namespace WAApiNET.ServerAnswers.Task
{
    internal class GetWholeTaskAnswer : BaseAnswer
    {
        internal class DataObj
        {
            public WATaskWhole Task { get; set; }

            public DataObj()
            {
                this.Task = new WATaskWhole();
            }
        }

        public DataObj Data { get; set; }

        public GetWholeTaskAnswer()
        {
            this.Data = new DataObj();
        }
    }
}