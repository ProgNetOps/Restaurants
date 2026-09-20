using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        //Dynamically retrieving the connection string defined in appsettings.json file
        var connectionString = configuration.GetConnectionString("RestaurantsDbConnectionString");
        services.AddDbContext<RestaurantsDbContext>(options =>
        options.UseSqlServer(connectionString));

    }
}
