#region Using

using WAApiNET.Model.Account;

#endregion

namespace WAApiNET.ServerAnswers.Account
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