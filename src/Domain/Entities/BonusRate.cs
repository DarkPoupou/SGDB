namespace CleanArchitecture.Domain.Entities;

public class BonusRate
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Rate { get; set; }
    public Plan Plan { get; set; }
}