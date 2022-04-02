namespace CleanArchitecture.Domain.Entities;

public class Reservation
{
    public int Id { get; set; }
    public Client Client { get; set; }
    public int ClientId { get; set; }
    public Vehicle Vehicle { get; set; }
    public int VehicleId { get; set; }
    public Plan Plan { get; set; }
    public int PlanId { get; set; }
    public ReservationStatus ReservationStatus { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}