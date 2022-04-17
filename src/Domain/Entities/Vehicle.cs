using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain.Entities;

public class Vehicle
{
    public int Id { get; set; }
    public ICollection<Reservation> Reservations{ get; set; }
    [MaxLength(50)]
    public string Immatriculation { get; set; }
    public double Kilometer { get; set; }
    public Brand Brand { get; set; }
    public int BrandId { get; set; }
    public Depot Depot { get; set; }
    public int DepotId { get; set; }
}