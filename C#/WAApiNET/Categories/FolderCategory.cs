#region Using

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WAApiNET.Exception;
using WAApiNET.Model.Folder;
using WAApiNET.ServerAnswers.Folder;
using WAApiNET.ServerQueries;
using WAApiNET.ServerQueries.Folder;

#endregion

namespace WAApiNET.Categories
{
    /// <summary>
    /// Методы для работы с папками
    /// </summary>
    public class FolderCategory
    {
        private readonly WAApi _waApi;
        private readonly AccountCategory _accountCategory;

        /// <summary>
        /// Создает новый экземпляр
        /// </summary>
        /// <param name="waApi"></param>
        /// <param name="accountCategory"></param>
        public FolderCategory( WAApi waApi, AccountCategory accountCategory )
        {
            this._waApi = waApi;
            this._accountCategory = accountCategory;
        }

        /// <summary>
        /// Получение списка папок
        /// </summary>
        /// <returns></returns>
        public async Task<List<WAFolder>> GetFolders()
        {
            var getFoldersQ = new BaseQueryData( this._accountCategory.Token );
            string answer = await this._waApi.SendPost( "Get folders", getFoldersQ );
            var getFoldersA = JsonConvert.DeserializeObject<GetFoldersAnswer>( answer );
            return getFoldersA.Data.Folders;
        }

        /// <summary>
        /// Добавление папки
        /// </summary>
        /// <param name="name">Имя папки</param>
        /// <returns></returns>
        public async Task<WAFolder> AddFolder( string name )
        {
            var addFolderQ = new AddFolderQuery( this._accountCategory.Token, name );
            string answer = await this._waApi.SendPost( "Add folder", addFolderQ );
            var addFolderA = JsonConvert.DeserializeObject<AddFolderAnswer>( answer );
            return new WAFolder( addFolderA.Data.FolderId, name, 0 );
        }

        /// <summary>
        /// Изменение имени папки
        /// </summary>
        /// <param name="folderId">Id папки</param>
        /// <param name="newName">Новое имя</param>
        /// <returns></returns>
        public async Task SetFolderName( int folderId, string newName )
        {
            var changeFolderNameQ = new ChangeFolderNameQuery( this._accountCategory.Token, folderId, newName );
            await this._waApi.SendPost( "Set folder name", changeFolderNameQ );
        }

        /// <summary>
        /// Изменение имени папки
        /// </summary>
        /// <param name="folder">Объект папки</param>
        /// <param name="newName">Новое имя</param>
        /// <returns></returns>
        public async Task SetFolderName( WAFolder folder, string newName )
        {
            if ( folder == null || folder.FolderId == null )
            {
                throw new WAApiException( "Некорректный параметр: folder!" );
            }
            await this.SetFolderName( (int)folder.FolderId, newName );
        }

        /// <summary>
        /// Удаление папок
        /// </summary>
        /// <param name="folderIds">Массив id папок</param>
        /// <returns></returns>
        public async Task DeleteFolders( int[] folderIds )
        {
            if ( folderIds == null || folderIds.Length == 0 )
            {
                throw new WAApiException( "Некорректный параметр: foldersIds!" );
            }
            var deleteFoldersQ = new DeleteFoldersQuery( this._accountCategory.Token, folderIds );
            await this._waApi.SendPost( "Delete folders", deleteFoldersQ );
        }

        /// <summary>
        /// Удаление папок
        /// </summary>
        /// <param name="folders">Массив папок</param>
        /// <returns></returns>
        public async Task DeleteFolders( WAFolder[] folders )
        {
            if ( folders == null || folders.Length == 0 || folders.Any( f => f.FolderId == null ) )
            {
                throw new WAApiException( "Некорректный параметр: folders!" );
            }
            int[] folderIds = folders.Select( f => f.FolderId != null ? (int)f.FolderId : 0 ).ToArray();
            await this.DeleteFolders( folderIds );
        }

        /// <summary>
        /// Получение всех данных папки
        /// </summary>
        /// <param name="folderId">Id папки</param>
        /// <returns></returns>
        public async Task<WAFolderWhole> GetWholeFolder( int folderId )
        {
            var getWholeFolderQ = new GetWholeFolderQuery( this._accountCategory.Token, folderId );
            string answer = await this._waApi.SendPost( "Get whole folder", getWholeFolderQ );
            var getWholeFolderA = JsonConvert.DeserializeObject<GetWholeFolderAnswer>( answer );
            return getWholeFolderA.Data.Folder;
        }

        /// <summary>
        /// Получение всех данных папки
        /// </summary>
        /// <param name="folder">Папка</param>
        /// <returns></returns>
        public async Task<WAFolderWhole> GetWholeFolder( WAFolder folder )
        {
            if ( folder == null || folder.FolderId == null )
            {
                throw new WAApiException( "Некорректный параметр: folder!" );
            }
            return await this.GetWholeFolder( (int)folder.FolderId );
        }
    }
}