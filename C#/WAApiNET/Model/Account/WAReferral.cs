#region Using

using System;

#endregion

namespace WAApiNET.Model.Account
{
    /// <summary>
    /// Объект реферала
    /// </summary>
    public class WAReferral : IEquatable<WAReferral>
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
        public double? Deductions { get; set; }

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

        #region Members

        public bool Equals( WAReferral other )
        {
            if ( ReferenceEquals( null, other ) )
            {
                return false;
            }
            if ( ReferenceEquals( this, other ) )
            {
                return true;
            }
            return string.Equals( this.Login, other.Login );
        }

        public override bool Equals( object obj )
        {
            if ( ReferenceEquals( null, obj ) )
            {
                return false;
            }
            if ( ReferenceEquals( this, obj ) )
            {
                return true;
            }
            if ( obj.GetType() != this.GetType() )
            {
                return false;
            }
            return this.Equals( (WAReferral)obj );
        }

        public override int GetHashCode()
        {
            return ( this.Login != null ? this.Login.GetHashCode() : 0 );
        }

        public static bool operator ==( WAReferral left, WAReferral right )
        {
            return Equals( left, right );
        }

        public static bool operator !=( WAReferral left, WAReferral right )
        {
            return !Equals( left, right );
        }

        #endregion
    }
}