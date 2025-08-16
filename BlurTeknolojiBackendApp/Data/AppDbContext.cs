using BlurTeknolojiBackendApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlurTeknolojiBackendApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Enterprise> Enterprises { get; set; }
        
     
        public DbSet<TaxAddress> TaxAddresses { get; set; }
    }
}
  