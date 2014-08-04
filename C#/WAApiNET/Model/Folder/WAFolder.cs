#region Using

using Newtonsoft.Json;

#endregion

namespace WAApiNET.Model.Folder
{
    /// <summary>
    /// Объект папки
    /// </summary>
    public class WAFolder
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
    }
}