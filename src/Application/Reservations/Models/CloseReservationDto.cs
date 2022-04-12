using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.Configuration.Annotations;
using CleanArchitecture.Application.Clients.Modells;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Application.Vehicles.Models;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Application.Reservations.Models;
public class CloseReservationDto: IMapFrom<Reservation>
{
    public int Id { get; set; }
    public ClientDto Client { get; set; }
    public int ClientId { get; set; }
    public VehicleDto Vehicle { get; set; }
    public int VehicleId { get; set; }
    public PlanDto Plan { get; set; }
    public int PlanId { get; set; }
    public ReservationStatus ReservationStatus { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public double Kilometers { get; set; } = 0;
    public double Price { get; set; }
}
