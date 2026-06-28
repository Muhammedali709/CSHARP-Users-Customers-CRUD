using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace C__FIRST_PROJECT
{
    public static class DALC
    {
        public static string GetConnectionString()
        {
            string constring = "Data Source=localhost\\SQLEXPRESS; Initial Catalog=DB.Customers; Integrated Security=true;";
            return constring;
        }
    }
}
