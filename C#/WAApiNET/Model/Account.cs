namespace WAApiNET.Model
{
    public class Account
    {
        public int? Id { get; set; }
        public int? Balance { get; set; }
        public string Mail { get; set; }
        public int? Timebonus { get; set; }
        public string Login { get; set; }
        public bool Deleted { get; set; }
        public string ReadonlyKey { get; set; }
        public string Referer { get; set; }

        /// <summary>
        /// Создает новый экземпляр класса, все поля имеют значение null
        /// </summary>
        public Account()
        {
            this.Id = null;
            this.Balance = null;
            this.Mail = null;
            this.Timebonus = null;
            this.Login = null;
            this.Deleted = false;
            this.ReadonlyKey = null;
            this.Referer = null;
        }

        public Account( int? id, int? balance, string mail, int? timebonus, string login, bool deleted,
            string readonlyKey, string referer )
        {
            this.Id = id;
            this.Balance = balance;
            this.Mail = mail;
            this.Timebonus = timebonus;
            this.Login = login;
            this.Deleted = deleted;
            this.ReadonlyKey = readonlyKey;
            this.Referer = referer;
        }
    }
}