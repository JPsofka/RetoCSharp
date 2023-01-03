using Microsoft.EntityFrameworkCore;
using Reto.Domain.Entities;


namespace Reto.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

    }
}
