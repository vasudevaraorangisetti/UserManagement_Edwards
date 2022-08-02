using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Common
{
    public static class Constants
    {
        public static string BaseAddress = "http://localhost:9000/";

        public static int MaxUserId = 0;

        public static string DirectoryLocation = @"C:\UserManagement_Edwards";

        public static string FileName = "UserList.json";

        public static string FullFilePath = DirectoryLocation + "\\" + FileName;

    }
}
