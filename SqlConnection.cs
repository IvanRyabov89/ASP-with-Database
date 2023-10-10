using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_с_бд
{
    public class SqlConnection
    {
        public SQLContext UserContext { get; private set; }
        public List<ModelSQL> ListUsers { get; private set; }
        public SqlConnection(string adress)
        {
            UserContext = new SQLContext();
            ListUsers = new List<ModelSQL>();
        }
        public List<ModelSQL> SelectUsers()
        {
            ListUsers = UserContext.ModelSQLNew.ToList();
            return ListUsers;
        }
    }
}
