using Microsoft.EntityFrameworkCore;

namespace ShuttleProject.Models
{
    public class AppDbContext : DbContext
    {
        private AppDbContext _appDbContext;

        public AppDbContext(DbContextOptions options) :base(options)
        { 

        }

        public DbSet<Drivers> Drivers {  get; set; }
        public DbSet<Passengers> Passengers { get;  set; }
        public DbSet<Shuttles> Shuttles { get; set; }
        public DbSet<Routes> Routes { get; set; }
    }
}
