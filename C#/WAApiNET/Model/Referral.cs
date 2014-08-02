namespace WAApiNET.Model
{
    public class Referral
    {
        public string Login { get; set; }
        public int? Inactivity { get; set; }
        public int? Deductions { get; set; }

        public Referral()
        {
            this.Login = null;
            this.Inactivity = null;
            this.Deductions = null;
        }

        public Referral( string login, int? inactivity, int? deductions )
        {
            this.Login = login;
            this.Inactivity = inactivity;
            this.Deductions = deductions;
        }
    }
}