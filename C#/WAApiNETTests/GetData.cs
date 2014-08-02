#region Using

using System.IO;

#endregion

namespace WAApiNETTests
{
    internal class GetData
    {
        public string Mail { get; set; }
        public string Password { get; set; }

        public GetData()
        {
            var content = File.ReadAllText( "loginInfo.txt" );
            string[] arr = content.Split( ';' );
            this.Mail = arr[ 0 ];
            this.Password = arr[ 1 ];
        }
    }
}