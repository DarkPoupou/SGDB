using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Application.Vehicles.Models;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Application.Reservations.Models;
public class ReservationDto: IMapFrom<Reservation>
{
    public int Id { get; set; }
    public VehicleDto Vehicle { get; set; }
    public ReservationStatus ReservationStatus { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public double Price { get; set; }
    public PlanType PlanPlanType { get; set; }
    public int PlanStartDepotId { get; set; }
    public int PlanEndDepotId { get; set; }
}
