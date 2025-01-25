using Microsoft.EntityFrameworkCore;

namespace Discount.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Domain.Entities.Discount> Discounts { get; set; }
    }
}
