using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Application.Reservations.Models;

public interface IPriceReservationCalculModel
{
    DateTime EndDate { get; set; }
    int PlanEndDepotId { get; set; }
    double Kilometers { get; set; }
    double PlanKilometerPrice { get; set; }
    int PlanStartDepotId { get; set; }
    DateTime StartDate { get; set; }
    CarNotoriety VehicleBrandNotoriety { get; set; }
    PlanType PlanPlanType { get; set; }
    public double PlanBonusRate { get; set; }

}

public class PriceReservationCalculModel : ReservationDto, IPriceReservationCalculModel
{
    public double PlanBonusRate { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public double Kilometers { get; set; } = 0;
    public CarNotoriety VehicleBrandNotoriety { get; set; }
    public double PlanKilometerPrice { get; set; }
    public int PlanStartDepotId { get; set; }
    public int PlanEndDepotId { get; set; }
    public PlanType PlanPlanType { get; set; }
}
