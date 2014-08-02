namespace WAApiNET.ServerQueries
{
    internal class AddFolderQuery : BaseQueryData
    {
        public string Name { get; set; }

        public AddFolderQuery()
        {
            this.Name = null;
        }

        public AddFolderQuery( string token, string name )
            : base( token )
        {
            this.Name = name;
        }
    }
}