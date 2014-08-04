namespace WAApiNET.Model.Account
{
    /// <summary>
    /// Объект реферала
    /// </summary>
    public class WAReferral
    {
        /// <summary>
        /// Логин
        /// </summary>
        public string Login { get; set; }
        /// <summary>
        /// Время неактивности (в днях)
        /// </summary>
        public int? Inactivity { get; set; }
        /// <summary>
        /// Доход (в кредитах)
        /// </summary>
        public int? Deductions { get; set; }

        /// <summary>
        /// Создает новый экземпляр, все поля имеют значения null
        /// </summary>
        public WAReferral()
        {
            this.Login = null;
            this.Inactivity = null;
            this.Deductions = null;
        }

        /// <summary>
        /// Создает новый экземпляр с указанными параметрами
        /// </summary>
        /// <param name="login"></param>
        /// <param name="inactivity"></param>
        /// <param name="deductions"></param>
        public WAReferral( string login, int? inactivity, int? deductions )
        {
            this.Login = login;
            this.Inactivity = inactivity;
            this.Deductions = deductions;
        }
    }
}