#region Using

using System.Collections.Generic;
using WAApiNET.Model.Account;
using WAApiNET.Model.Folder;

#endregion

namespace WAApiNET.Model
{
    /// <summary>
    /// Объект всей информации об аккаунте
    /// </summary>
    public class WAAllInfo
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
    }
}