namespace CleanArchitecture.Domain.Entities;

public class Fee
{
    public int Id { get; set; }
    public double Price { get; set; }
    public Depot Depot1 { get; set; }
    public int Depot1Id { get; set; }
    public Depot Depot2 { get; set; }
    public int Depot2Id { get; set; }
}