namespace CleanArchitecture.Domain.Entities;

public class Brand
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public Vehicle Vehicle { get; set; }
}