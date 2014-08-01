namespace WAApiNET.ServerQueries
{
    public abstract class BaseQuery
    {
        public string Action { get; set; }

        public BaseQuery()
        {
            this.Action = null;
        }
    }
}