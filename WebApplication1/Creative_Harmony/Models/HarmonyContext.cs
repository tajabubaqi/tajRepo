using Microsoft.EntityFrameworkCore;

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
            optionsBuilder.UseSqlServer(Startup.ConnectionString);
        }
    }
}
