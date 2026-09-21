using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants;

namespace Restaurants.API.Controllers;

[ApiController]
[Route("api/restaurants")]
public class RestaurantsController(IRestaurantsService restaurantsService) :ControllerBase
{
    private readonly IRestaurantsService _restaurantsService = restaurantsService;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
       var restaurants =await _restaurantsService.GetAllRestaurants();
        return Ok(restaurants);
    }
}
