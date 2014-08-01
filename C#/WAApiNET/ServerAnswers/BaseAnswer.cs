namespace WAApiNET.ServerAnswers
{
    public abstract class BaseAnswer
    {
        public string Status { get; set; }

        public BaseAnswer()
        {
            this.Status = null;
        }
    }
}