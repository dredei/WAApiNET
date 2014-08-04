namespace WAApiNET.Model
{
    public class WAReferral
    {
        public string Login { get; set; }
        public int? Inactivity { get; set; }
        public int? Deductions { get; set; }

        public WAReferral()
        {
            this.Login = null;
            this.Inactivity = null;
            this.Deductions = null;
        }

        public WAReferral( string login, int? inactivity, int? deductions )
        {
            this.Login = login;
            this.Inactivity = inactivity;
            this.Deductions = deductions;
        }
    }
}