namespace CleanArchitecture.Domain.Entities;

public class Notoriety
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Coefficient { get; set; }
    public Vehicle Vehicle { get; set; }
}