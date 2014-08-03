#region Using

using WAApiNET.Model;

#endregion

namespace WAApiNET.ServerAnswers
{
    internal class GetWholeTaskAnswer : BaseAnswer
    {
        internal class DataObj
        {
            public WATaskExtend Task { get; set; }

            public DataObj()
            {
                this.Task = new WATaskExtend();
            }
        }

        public DataObj Data { get; set; }

        public GetWholeTaskAnswer()
        {
            this.Data = new DataObj();
        }
    }
}