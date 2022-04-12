namespace CleanArchitecture.Domain.Entities;

public class Plan
{
    public int Id { get; set; }
    public BonusRate BonusRate { get; set; }
    public int BonusRateId { get; set; }
    public PlanType PlanType { get; set; }
    public Reservation Reservation { get; set; }
    public Depot StartDepot { get; set; }
    public int StartDepotId { get; set; }
    public Depot EndDepot { get; set; }
    public int EndDepotId { get; set; }
    public double? KilometerPrice { get; set; }
}