using Restaurants.Application.Dishes.Dtos;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Restaurants.Dtos;
/// <summary>
/// Properties sent to client during a get request
/// </summary>
public class RestaurantDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Category { get; set; }
    public bool HasDelivery { get; set; }

    //The properties from the Address entity
    public string? City { get; set; }
    public string? Street { get; set; }
    public string? PostalCode { get; set; }


    public List<DishDto> Dishes { get; set; } = new();



}
