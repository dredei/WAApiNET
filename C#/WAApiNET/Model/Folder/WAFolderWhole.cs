#region Using

using System;
using System.Collections.Generic;
using WAApiNET.Model.Task;

#endregion

namespace WAApiNET.Model.Folder
{
    /// <summary>
    /// Объект папки (со списком заданий)
    /// </summary>
    public class WAFolderWhole : WAFolder, IEquatable<WAFolderWhole>
    {
        /// <summary>
        /// Список заданий
        /// </summary>
        public new List<WATaskWhole> Tasks { get; set; }

        /// <summary>
        /// Создает новый экземпляр
        /// </summary>
        public WAFolderWhole()
        {
            this.Tasks = new List<WATaskWhole>();
        }

        #region Members

        public bool Equals( WAFolderWhole other )
        {
            if ( ReferenceEquals( null, other ) )
            {
                return false;
            }
            if ( ReferenceEquals( this, other ) )
            {
                return true;
            }
            return base.Equals( other ) && Equals( this.Tasks, other.Tasks );
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
            return this.Equals( (WAFolderWhole)obj );
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ( base.GetHashCode() * 397 ) ^ ( this.Tasks != null ? this.Tasks.GetHashCode() : 0 );
            }
        }

        public static bool operator ==( WAFolderWhole left, WAFolderWhole right )
        {
            return Equals( left, right );
        }

        public static bool operator !=( WAFolderWhole left, WAFolderWhole right )
        {
            return !Equals( left, right );
        }

        #endregion
    }
}