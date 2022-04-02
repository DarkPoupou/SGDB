namespace CleanArchitecture.Domain.Entities;

public class Role
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Employee>? Employee { get; set; }
}