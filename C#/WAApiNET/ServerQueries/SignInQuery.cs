namespace WAApiNET.ServerQueries
{
    internal class SignInQuery
    {
        public string Mail { get; set; }
        public string Password { get; set; }

        public SignInQuery( string mail, string password )
        {
            this.Mail = mail;
            this.Password = password;
        }
    }
}