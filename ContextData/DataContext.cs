using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_с_бд.AuthTelephoneDescriptionApp;
using ASP_с_бд.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ASP_с_бд.ContextData
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions options) : base(options) { }
        public DbSet<TelephoneDescription> telephoneDescriptions { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(
        //        @"Server=(localdb)\MSSQLLocalDB;
        //          DataBase=_EntityCoreASP_с_бд;
        //          Trusted_Connection=True;"
        //        );
        //}
    }
}
