using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagementSystem
{
    internal class Utils
    {
        public static string DBConnection()
        {
            return $"Server=localhost;DataBase=POS;Trusted_Connection=True";
        }
    }
}
