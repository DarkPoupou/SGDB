using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Domain.Entities;
[Index(nameof(Name), IsUnique=true)]
public class Country
{
    public int Id { get; set; }
    [MaxLength(200)]
    public string Name { get; set; }
    public double KilometerPrice { get; set; }
    public ICollection<Depot> Depots { get; set; }
}