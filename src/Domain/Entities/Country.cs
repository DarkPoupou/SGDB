namespace CleanArchitecture.Domain.Entities;

public class Country
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double KilometerPrice { get; set; }
    public ICollection<Depot> Depots { get; set; }
}