#region Using

using System.Collections.Generic;

#endregion

namespace WAApiNET.Model
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