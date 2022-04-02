namespace CleanArchitecture.Domain.Entities;

public class Vehicle
{
    public int Id { get; set; }
    public Reservation Reservation{ get; set; }
    public string Immatriculation { get; set; }
    public double KilometerTraveled { get; set; }
    public double Kilometer { get; set; }
    public Notoriety Notoriety { get; set; }
    public int NotorietyId { get; set; }
    public Brand Brand { get; set; }
    public int BrandId { get; set; }
    public Depot Depot { get; set; }
    public int DepotId { get; set; }
}