using Microsoft.EntityFrameworkCore;
using MODUL10_103022300134.Model;

namespace MODUL10_103022300134.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
         { 
        } 
          public DbSet<Movie> Movies { get; set; }
    }
}
