#region Using

using System;
using Newtonsoft.Json;

#endregion

namespace WAApiNET.Model.Folder
{
    /// <summary>
    /// Объект папки
    /// </summary>
    public class WAFolder : IEquatable<WAFolder>
    {
        /// <summary>
        /// Id папки
        /// </summary>
        [JsonProperty( PropertyName = "Folder ID" )]
        public int? FolderId { get; set; }

        /// <summary>
        /// Имя папки
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Количество заданий
        /// </summary>
        public int? Tasks { get; set; }

        /// <summary>
        /// Создает новый экземпляр, все поля имеют значения null
        /// </summary>
        public WAFolder()
        {
            this.FolderId = null;
            this.Name = null;
            this.Tasks = null;
        }

        /// <summary>
        /// Создает новый экземпляр с указанными параметрами
        /// </summary>
        /// <param name="folderId"></param>
        /// <param name="name"></param>
        /// <param name="tasks"></param>
        public WAFolder( int? folderId, string name, int? tasks )
            : this()
        {
            this.FolderId = folderId;
            this.Name = name;
            this.Tasks = tasks;
        }

        public bool Equals( WAFolder other )
        {
            if ( ReferenceEquals( null, other ) )
            {
                return false;
            }
            if ( ReferenceEquals( this, other ) )
            {
                return true;
            }
            return this.FolderId == other.FolderId && string.Equals( this.Name, other.Name ) &&
                   this.Tasks == other.Tasks;
        }

        #region Members

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
            return this.Equals( (WAFolder)obj );
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = this.FolderId.GetHashCode();
                hashCode = ( hashCode * 397 ) ^ ( this.Name != null ? this.Name.GetHashCode() : 0 );
                hashCode = ( hashCode * 397 ) ^ this.Tasks.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==( WAFolder left, WAFolder right )
        {
            return Equals( left, right );
        }

        public static bool operator !=( WAFolder left, WAFolder right )
        {
            return !Equals( left, right );
        }

        #endregion
    }
}