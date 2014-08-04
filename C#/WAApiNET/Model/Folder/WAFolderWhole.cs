#region Using

using System.Collections.Generic;
using WAApiNET.Model.Task;

#endregion

namespace WAApiNET.Model.Folder
{
    public class WAFolderWhole : WAFolder
    {
        public string Name { get; set; }
        public List<WATaskWhole> Tasks { get; set; }

        public WAFolderWhole()
        {
            this.Name = null;
            this.Tasks = new List<WATaskWhole>();
        }
    }
}