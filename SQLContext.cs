using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_с_бд
{
    public partial class SQLContext : DbContext
    {
        public SQLContext() : base("DbConnection")
        { }
        public virtual DbSet<ModelSQL> ModelSQLNew { get; set; }
    }
}
