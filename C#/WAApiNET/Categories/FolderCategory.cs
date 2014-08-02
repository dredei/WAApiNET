﻿#region Using

using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WAApiNET.Model;
using WAApiNET.ServerAnswers;
using WAApiNET.ServerQueries;

#endregion

namespace WAApiNET.Categories
{
    public class FolderCategory
    {
        private readonly WAApi _waApi;
        private readonly AccountCategory _accountCategory;

        public FolderCategory( WAApi waApi, AccountCategory accountCategory )
        {
            this._waApi = waApi;
            this._accountCategory = accountCategory;
        }

        /// <summary>
        /// Получение списка папок
        /// </summary>
        /// <returns></returns>
        public async Task<List<Folder>> GetFolders()
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
        public async Task<Folder> AddFolder( string name )
        {
            var addFolderQ = new AddFolderQuery( this._accountCategory.Token, name );
            string answer = await this._waApi.SendPost( "Add folder", addFolderQ );
            var addFolderA = JsonConvert.DeserializeObject<AddFolderAnswer>( answer );
            return new Folder( addFolderA.Data.FolderId, name, 0 );
        }
    }
}