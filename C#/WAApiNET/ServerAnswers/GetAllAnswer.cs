#region Using

using WAApiNET.Model;

#endregion

namespace WAApiNET.ServerAnswers
{
    internal class GetAllAnswer
    {
        public WAAllInfo Data { get; set; }

        public GetAllAnswer()
        {
            this.Data = null;
        }
    }
}