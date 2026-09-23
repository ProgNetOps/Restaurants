using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.API.Controllers;

[ApiController]
[Route("api/restaurants")]
public class RestaurantsController(IRestaurantsService restaurantsService) : ControllerBase
{
    private readonly IRestaurantsService _restaurantsService = restaurantsService;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var restaurants = await _restaurantsService.GetAllRestaurants();
        return Ok(restaurants);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute]int id)
    {
        var restaurant = await _restaurantsService.GetRestaurantById(id);
        
        if(restaurant is null)
        {
            return NotFound();
        }
        else
        {
            return Ok(restaurant);
        }
    }


    [HttpPost]
    public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantDto createRestaurantDto)
    {
        int id = await _restaurantsService.Create(createRestaurantDto);
        return CreatedAtAction(nameof(GetById), new {id},null);
    }
}
