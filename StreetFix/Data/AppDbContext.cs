using Microsoft.EntityFrameworkCore;
using StreetFix.Models;

namespace StreetFix.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        
        public DbSet<Report> Report { get; set; }
        
    }
}