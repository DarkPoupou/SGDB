using System.Collections.Generic;

namespace CleanArchitecture.Domain.Entities;

public class Depot
{
    public int Id { get; set; }
    public ICollection<Vehicle> Vehicle { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public Country Country { get; set; }
    public int CountryId { get; set; }
    public ICollection<Fee> Depot1 { get; set; }
    public ICollection<Fee> Depot2 { get; set; }
}