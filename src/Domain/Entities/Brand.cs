using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain.Entities;

public class Brand
{
    public int Id { get; set; }
    [MaxLength(200)]
    public string Name { get; set; }
    [MaxLength(200)]
    public string Model { get; set; }
    public Vehicle Vehicle { get; set; }
    public CarNotoriety Notoriety { get; set; }
}