using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurants.Application.Restaurants;

internal class RestaurantsService(IRestaurantsRepository restaurantsRepository,
    ILogger<Restaurant> logger) : IRestaurantsService
{
    private readonly IRestaurantsRepository _restaurantsRepository = restaurantsRepository;
    private readonly ILogger _logger = logger;

    public async Task<IEnumerable<RestaurantDto>> GetAllRestaurants()
    {
        _logger.LogInformation("Getting all restaurants");
        var restaurants = await restaurantsRepository.GetAllAsync();

        var restaurantsDtos = restaurants.Select(RestaurantDto.FromEntity);


        return restaurantsDtos!;
    }

    public async Task<RestaurantDto?> GetRestaurantById(int id)
    {
        _logger.LogInformation($"Getting restaurant with id, {id}");
        var restaurant = await _restaurantsRepository.GetByIdAsync(id);

        var restaurantDto = RestaurantDto.FromEntity(restaurant);
        return restaurantDto;
    }
}
