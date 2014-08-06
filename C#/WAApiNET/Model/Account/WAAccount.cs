#region Using

using System;
using Newtonsoft.Json;

#endregion

namespace WAApiNET.Model.Account
{
    /// <summary>
    /// Объект аккаунта
    /// </summary>
    public class WAAccount : IEquatable<WAAccount>
    {
        /// <summary>
        /// Id аккаунта
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Баланс
        /// </summary>
        public int? Balance { get; set; }

        /// <summary>
        /// Почта
        /// </summary>
        public string Mail { get; set; }

        /// <summary>
        /// Таймбонус
        /// </summary>
        public int? Timebonus { get; set; }

        /// <summary>
        /// Логин
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Удален ли аккаунт
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// Гостевой ключ
        /// </summary>
        [JsonProperty( PropertyName = "Readonly key" )]
        public string ReadonlyKey { get; set; }

        /// <summary>
        /// Реферер
        /// </summary>
        public string Referer { get; set; }

        /// <summary>
        /// Создает новый экземпляр класса, все поля имеют значение null
        /// </summary>
        public WAAccount()
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

        /// <summary>
        /// Создает новый экземпляр класса с указанными параметрами
        /// </summary>
        /// <param name="id"></param>
        /// <param name="balance"></param>
        /// <param name="mail"></param>
        /// <param name="timebonus"></param>
        /// <param name="login"></param>
        /// <param name="deleted"></param>
        /// <param name="readonlyKey"></param>
        /// <param name="referer"></param>
        public WAAccount( int? id, int? balance, string mail, int? timebonus, string login, bool deleted,
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

        #region Members

        public bool Equals( WAAccount other )
        {
            if ( ReferenceEquals( null, other ) )
            {
                return false;
            }
            if ( ReferenceEquals( this, other ) )
            {
                return true;
            }
            return this.Id == other.Id && string.Equals( this.Mail, other.Mail ) &&
                   string.Equals( this.Login, other.Login ) && string.Equals( this.Referer, other.Referer );
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
            return this.Equals( (WAAccount)obj );
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = this.Id.GetHashCode();
                hashCode = ( hashCode * 397 ) ^ ( this.Mail != null ? this.Mail.GetHashCode() : 0 );
                hashCode = ( hashCode * 397 ) ^ ( this.Login != null ? this.Login.GetHashCode() : 0 );
                hashCode = ( hashCode * 397 ) ^ ( this.Referer != null ? this.Referer.GetHashCode() : 0 );
                return hashCode;
            }
        }

        public static bool operator ==( WAAccount left, WAAccount right )
        {
            return Equals( left, right );
        }

        public static bool operator !=( WAAccount left, WAAccount right )
        {
            return !Equals( left, right );
        }

        #endregion
    }
}