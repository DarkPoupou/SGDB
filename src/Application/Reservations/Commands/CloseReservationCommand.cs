using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Reservations.Models;
using CleanArchitecture.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Reservations.Commands;
public class CloseReservationCommand: IRequest<CloseReservationDto>
{
    public int ReservationId { get; set; }
    public double NbKilometers { get; set; }
    public int DepotId { get; set; }
}
public class CloseReservationCommandHandler : IRequestHandler<CloseReservationCommand, CloseReservationDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IPriceCalculationService _priceCalculation;

    public CloseReservationCommandHandler(IApplicationDbContext context, IMapper mapper, IPriceCalculationService priceCalculation)
    {
        _context = context;
        _mapper = mapper;
        _priceCalculation = priceCalculation;
    }
    public async Task<CloseReservationDto> Handle(CloseReservationCommand request, CancellationToken cancellationToken)
    {
        var reservation = await _context.Reservations.FindAsync(request.ReservationId);
        double price = await _priceCalculation.CalculReservationPriceAsync(_mapper.Map<PriceReservationCalculModel>(reservation), Math.Max(request.NbKilometers, request.DepotId));
        if(reservation.Plan.PlanType == PlanType.Kilometric)
        {
            reservation.Kilometers = request.NbKilometers;
            //price = _priceCalculation.KilometricPriceCalcul(reservation.Plan.KilometerPrice, reservation.Kilometers, reservation.Vehicle.Brand.Notoriety);
            //price = reservation.Plan.KilometerPrice * reservation.Kilometers * Math.Sqrt((int)reservation.Vehicle.Brand.Notoriety);
        }
        else
        {
            var endDepot = _context.Depots.FirstOrDefault(r => r.Id == request.DepotId) ?? throw new NotFoundException(nameof(request.DepotId));
            //var fee = await _context.Fees.FirstOrDefaultAsync(
            //    f => (f.Depot1Id == reservation.Plan.StartDepotId && f.Depot2Id == reservation.Plan.EndDepotId)
            //    || (f.Depot1Id == reservation.Plan.EndDepotId && f.Depot2Id == reservation.Plan.StartDepotId)) 
            //    ?? throw new NotFoundException("no fee found");

            //var endDepotRate = endDepot.Id == reservation.Plan.EndDepotId ? 0.95 : 1.1;
            //var nbDays = (reservation.EndDate.Date - reservation.StartDate.Date).TotalDays;
            //price = (int)nbDays * fee.Price * endDepotRate * Math.Sqrt((int)reservation.Vehicle.Brand.Notoriety);
            reservation.Plan.EndDepot = endDepot;
        }
        reservation.Price = price;
        reservation.ReservationStatus = ReservationStatus.Comlpeted;
        await _context.SaveChangesAsync(cancellationToken);
        return await _context.Reservations.ProjectTo<CloseReservationDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(f => f.Id == request.ReservationId)
            ?? throw new NotFoundException(nameof(request.ReservationId), request.ReservationId);    
    }
}
