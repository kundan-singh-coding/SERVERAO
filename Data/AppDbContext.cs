using Microsoft.EntityFrameworkCore;
using SWICN.Model;

namespace SWICN.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { } 
        public DbSet<User> Users { get; set; }
    }
}
