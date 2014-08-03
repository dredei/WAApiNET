#region Using

using System.Collections.Generic;

#endregion

namespace WAApiNET.Model
{
    public class FolderWhole : Folder
    {
        public string Name { get; set; }
        public List<WATaskExtend> Tasks { get; set; }

        public FolderWhole()
        {
            this.Name = null;
            this.Tasks = new List<WATaskExtend>();
        }
    }
}