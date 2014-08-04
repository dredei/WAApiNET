#region Using

using System.Collections.Generic;
using WAApiNET.Model.Task;

#endregion

namespace WAApiNET.Model.Folder
{
    /// <summary>
    /// Объект папки (со списком заданий)
    /// </summary>
    public class WAFolderWhole : WAFolder
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
    }
}