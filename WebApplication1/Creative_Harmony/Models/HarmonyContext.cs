using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Creative_Harmony.Models
{
    public class HarmonyContext : DbContext
    {
        public DbSet<Employees> employees { get; set; }
        public DbSet<Partners> partners { get; set; }
        public DbSet<Users> users { get; set; }
        public DbSet<OurWorks> ourWorks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=harmony;User Id=sa;Password=sasa;");
        }
    }
}
