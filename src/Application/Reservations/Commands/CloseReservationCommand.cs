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
}
public class CloseReservationCommandHandler : IRequestHandler<CloseReservationCommand, CloseReservationDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CloseReservationCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<CloseReservationDto> Handle(CloseReservationCommand request, CancellationToken cancellationToken)
    {
        var reservation = await _context.Reservations.FirstOrDefaultAsync(r => r.Id == request.ReservationId);
        double price = 0;
        if(reservation.Plan.PlanType == PlanType.Kilometric)
        {
            reservation.Kilometers = request.NbKilometers;
            price = reservation.Plan.KilometerPrice.Value * reservation.Kilometers * reservation.Vehicle.Notoriety.Coefficient;
        }
        else
        {
            var fee = await _context.Fees.FirstOrDefaultAsync(
                f => (f.Depot1Id == reservation.Plan.StartDepotId && f.Depot2Id == reservation.Plan.EndDepotId)
                || (f.Depot1Id == reservation.Plan.EndDepotId && f.Depot2Id == reservation.Plan.StartDepotId)) 
                ?? throw new NotFoundException("no fee found");

            var nbDays = (reservation.EndDate.Date - reservation.StartDate.Date).TotalDays;
            price = (int)nbDays * fee.Price * reservation.Vehicle.Notoriety.Coefficient;
        }
        reservation.Price = price;
        await _context.SaveChangesAsync(cancellationToken);
        return await _context.Reservations.ProjectTo<CloseReservationDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(f => f.Id == request.ReservationId);        
    }
}
