namespace Restaurants.Domain.Entities;

public class Address
{
    //No Id because we do not intend to create a table for address in the database
    public string? City { get; set; }
    public string? Street { get; set; }
    public string? PostalCode { get; set; }
}
