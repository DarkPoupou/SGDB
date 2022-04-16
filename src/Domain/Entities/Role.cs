using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain.Entities;

public class Role
{
    public int Id { get; set; }
    [MaxLength(200)]
    public string Name { get; set; }
    public ICollection<Employee>? Employee { get; set; }
}