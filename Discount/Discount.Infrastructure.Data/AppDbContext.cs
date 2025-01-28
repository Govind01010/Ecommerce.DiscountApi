using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Discount.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Domain.Entities.Discount> Discounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.SetTableName(ConvertToSnakeCase(entity.GetTableName()));
                foreach (var property in entity.GetProperties())
                {
                    property.SetColumnName(ConvertToSnakeCase(property.Name));
                }
            }
        }

        private string ConvertToSnakeCase(string name)
        {
            return Regex.Replace(name, "([a-z0-9])([A-Z])", "$1_$2").ToLower();
        }
    }
}
