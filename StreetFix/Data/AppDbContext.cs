using Microsoft.EntityFrameworkCore;
using StreetFix.Models;

namespace StreetFix.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
    }
        public DbSet<Report> Report { get; set; }
    }
}
