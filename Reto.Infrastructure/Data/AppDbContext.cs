using Microsoft.EntityFrameworkCore;
using Reto.Domain.Entities;


namespace Reto.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> products { get; set; }
        public DbSet<Order> orders { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
