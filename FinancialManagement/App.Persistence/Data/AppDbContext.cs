using App.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Persistence.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext() : base("AppDbContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AppDbContext, App.Persistence.Migrations.Configuration>());
        }

        public DbSet<Group> Groups { get; set; }
    }
}
