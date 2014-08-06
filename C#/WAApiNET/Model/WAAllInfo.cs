#region Using

using System;
using System.Collections.Generic;
using WAApiNET.Model.Account;
using WAApiNET.Model.Folder;

#endregion

namespace WAApiNET.Model
{
    /// <summary>
    /// Объект всей информации об аккаунте
    /// </summary>
    public class WAAllInfo : IEquatable<WAAllInfo>
    {
        /// <summary>
        /// Список папок аккаунта
        /// </summary>
        public List<WAFolderWhole> Folders { get; set; }

        /// <summary>
        /// Список рефералов аккаунта
        /// </summary>
        public List<WAReferral> Referrals { get; set; }

        /// <summary>
        /// Создает новый экземпляр, все поля имеют значения null
        /// </summary>
        public WAAllInfo()
        {
            this.Folders = null;
            this.Referrals = null;
        }

        #region Members

        public bool Equals( WAAllInfo other )
        {
            if ( ReferenceEquals( null, other ) )
            {
                return false;
            }
            if ( ReferenceEquals( this, other ) )
            {
                return true;
            }
            return Equals( this.Referrals, other.Referrals ) && Equals( this.Folders, other.Folders );
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
            return this.Equals( (WAAllInfo)obj );
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ( ( this.Referrals != null ? this.Referrals.GetHashCode() : 0 ) * 397 ) ^
                       ( this.Folders != null ? this.Folders.GetHashCode() : 0 );
            }
        }

        public static bool operator ==( WAAllInfo left, WAAllInfo right )
        {
            return Equals( left, right );
        }

        public static bool operator !=( WAAllInfo left, WAAllInfo right )
        {
            return !Equals( left, right );
        }

        #endregion
    }
}