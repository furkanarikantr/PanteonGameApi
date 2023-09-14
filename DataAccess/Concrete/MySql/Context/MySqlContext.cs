using Entity.Concrete.MySqlEntities;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver.Core.Servers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.MySql.Context
{
    public class MySqlContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=94.73.147.101;port=3306;user=u1420260_panteon;password=2#Upy9T2yveSxkw%;database=u1420260_panteon", new MySqlServerVersion(new Version(8, 0, 34)));
        }

        public DbSet<User> Users { get; set; }
    }
}
