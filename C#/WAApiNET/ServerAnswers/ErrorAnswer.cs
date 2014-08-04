namespace WAApiNET.ServerAnswers
{
    internal class ErrorAnswer : BaseAnswer
    {
        public string Error { get; set; }

        public ErrorAnswer()
        {
            this.Error = null;
        }
    }
}