using AutoMapper;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants;

internal class RestaurantsService(IRestaurantsRepository restaurantsRepository,
    ILogger<Restaurant> logger,
    IMapper mapper) : IRestaurantsService
{
    private readonly IRestaurantsRepository _restaurantsRepository = restaurantsRepository;
    private readonly ILogger _logger = logger;
    private readonly IMapper _mapper = mapper;

    public async Task<int> Create(CreateRestaurantDto dto)
    {
        _logger.LogInformation("Creating a new restaurant");
        var restaurant = _mapper.Map<Restaurant>(dto);

        int id = await _restaurantsRepository.Create(restaurant);

        return id;
    }

    public async Task<IEnumerable<RestaurantDto>> GetAllRestaurants()
    {
        _logger.LogInformation("Getting all restaurants");
        var restaurants = await restaurantsRepository.GetAllAsync();

        var restaurantsDtos = _mapper.Map<IEnumerable<RestaurantDto>>(restaurants);

        return restaurantsDtos!;
    }

    public async Task<RestaurantDto?> GetRestaurantById(int id)
    {
        _logger.LogInformation($"Getting restaurant with id, {id}");
        var restaurant = await _restaurantsRepository.GetByIdAsync(id);

        var restaurantDto = _mapper.Map<RestaurantDto>(restaurant);
        return restaurantDto;
    }
}
