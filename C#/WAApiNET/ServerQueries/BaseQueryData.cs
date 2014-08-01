namespace WAApiNET.ServerQueries
{
    public class BaseQueryData
    {
        public string Token { get; set; }

        public BaseQueryData()
        {
            this.Token = null;
        }

        public BaseQueryData( string token )
        {
            this.Token = token;
        }
    }
}