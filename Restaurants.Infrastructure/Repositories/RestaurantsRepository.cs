using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Repositories;

internal class RestaurantsRepository(RestaurantsDbContext dbContext) : IRestaurantsRepository
{
    private readonly RestaurantsDbContext _dbContext = dbContext;

    public async Task<IEnumerable<Restaurant>> GetAllAsync()
    {
        var restaurants = await _dbContext.Restaurants.ToListAsync();
        return restaurants;
    }

    public async Task<Restaurant?> GetByIdAsync(int id)
    {
        var restaurant = await _dbContext.Restaurants.FirstOrDefaultAsync(x => x.Id == id);
        return restaurant;
    }
}
