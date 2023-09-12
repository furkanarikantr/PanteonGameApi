using Entity.Concrete.MySqlEntities;
using Microsoft.EntityFrameworkCore;
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
            optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=Furkarikan11;database=PanteonGameUser", new MySqlServerVersion(new Version(8, 0, 34)));
        }

        public DbSet<User> Users { get; set; }
    }
}
