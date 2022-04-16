using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain.Entities;

public class Depot
{
    public int Id { get; set; }
    public ICollection<Vehicle> Vehicle { get; set; }
    [MaxLength(200)]
    public string Name { get; set; }
    [MaxLength(400)]
    public string Address { get; set; }
    [MaxLength(200)]
    public string City { get; set; }
    public Country Country { get; set; }
    public int CountryId { get; set; }
    public ICollection<Fee> Depot1 { get; set; }
    public ICollection<Fee> Depot2 { get; set; }
}