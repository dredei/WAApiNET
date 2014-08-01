namespace WAApiNET.ServerAnswers
{
    internal class SignInAnswer : BaseAnswer
    {
        internal class DataObj
        {
            public string Token { get; set; }

            public DataObj()
            {
                this.Token = null;
            }
        }

        public DataObj Data { get; set; }

        public SignInAnswer()
        {
            this.Data = new DataObj();
        }
    }
}