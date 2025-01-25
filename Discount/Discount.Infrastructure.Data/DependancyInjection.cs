using Discount.Domain.Repository;
using Discount.Infrastructure.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Discount.Infrastructure.Data;

public static class DependancyInjection
{
    public static IServiceCollection AddInfrastructureData(this IServiceCollection services, string? connectionString)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddTransient<IGenericRepository<Domain.Entities.Discount>, GenericRepository<Domain.Entities.Discount>>();
        return services;
    }
}
