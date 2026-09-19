namespace Restaurants.Domain.Entities;

public class Address
{
    //No Id because we do not intend to separate it as a distinct entity
    //with a separate table for address in the database. W e only want the
    //address to be some kind of encapsulated property for the restaurant
    public string? City { get; set; }
    public string? Street { get; set; }
    public string? PostalCode { get; set; }
}
