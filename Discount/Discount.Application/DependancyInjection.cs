using Discount.Application.Messaging;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace Discount.Application
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(src => src.RegisterServicesFromAssemblyContaining<ICommand>());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
