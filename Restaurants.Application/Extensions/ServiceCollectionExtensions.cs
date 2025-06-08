using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Application.Dtos;

namespace Restaurants.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly));

            services.AddAutoMapper(typeof(ServiceCollectionExtensions).Assembly);
            services.AddValidatorsFromAssembly(typeof(ServiceCollectionExtensions).Assembly);

            //services.AddScoped<IValidator<CreateRestaurantDto>, CreateRestaurantValidator>();
        }
    }
}
