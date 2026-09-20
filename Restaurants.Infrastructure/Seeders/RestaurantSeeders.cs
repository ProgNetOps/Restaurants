using Restaurants.Domain.Entities;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Seeders;

internal class RestaurantSeeder(RestaurantsDbContext dbContext) : IRestaurantSeeder
{
    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            if (dbContext.Restaurants.Any() is false)
            {
                var restaurants = GetRestaurants();
                dbContext.Restaurants.AddRange(restaurants);
                await dbContext.SaveChangesAsync();
            }
        }
    }

    private IEnumerable<Restaurant> GetRestaurants()
    {
        List<Restaurant> restaurants = new()
        {
            new()
            {
                Name="KFC",
                Category="Fast Food",
                Description="American fast food restaurant chain headquarters",
                ContactEmail="contact@kfc.com",
                HasDelivery=true,
                Dishes=[
                    new()
                    {
                        Name="Nashville Hot Chicken",
                        Description="Nashville Hot Chicken (10 pcs.)",
                        Price=10.30M
                    },
                    new()
                    {
                        Name="Chicken Nuggets",
                        Description="Nashville Hot Chicken Nuggets (5 pcs.)",
                        Price=5.3M
                    }
                    ],
                Address = new()
                {
                    City="London",
                    Street="Cook street",
                    PostalCode="WC2N 3DY"
                }
            },
            new()
            {
                Name="Mr Bigg's",
                Category="Fast Food",
                Description="Mr Bigg's incorporated established 1908",
                ContactEmail="contact@mrbiggs.com",
                HasDelivery=true,
                Address = new()
                {
                    City="Lagos",
                    Street="Broad Street",
                    PostalCode="230109"
                }
            }
        };

        return restaurants;
    }
}
