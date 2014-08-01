namespace WAApiNET.ServerAnswers
{
    internal class SignInAnswer : BaseAnswer
    {
        public string Token { get; set; }

        public SignInAnswer()
        {
            this.Token = null;
        }
    }
}