#region Using

using WAApiNET.Model;

#endregion

namespace WAApiNET.ServerAnswers
{
    internal class GetGeneralInfoAnswer : BaseAnswer
    {
        public WAAccount Data { get; set; }

        public GetGeneralInfoAnswer()
        {
            this.Data = new WAAccount();
        }
    }
}