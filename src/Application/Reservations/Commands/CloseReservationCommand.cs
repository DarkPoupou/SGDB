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
        var reservation = await _context.Reservations.Include(r => r.Plan).Include(r => r.Vehicle).ThenInclude(v => v.Brand).FirstOrDefaultAsync(r => r.Id == request.ReservationId);
        if(reservation.Plan.PlanType == PlanType.Kilometric)
        {
            reservation.Kilometers = request.NbKilometers;
        }
        else
        {
            var endDepot = _context.Depots.FirstOrDefault(r => r.Id == request.DepotId) ?? throw new NotFoundException(nameof(request.DepotId));

            reservation.Plan.EndDepot = endDepot;
        }
        reservation.Price = await _priceCalculation.CalculReservationPriceAsync(_mapper.Map<PriceReservationCalculModel>(reservation), Math.Max(request.NbKilometers, request.DepotId));
        reservation.ReservationStatus = ReservationStatus.Comlpeted;
        await _context.SaveChangesAsync(cancellationToken);
        return await _context.Reservations.ProjectTo<CloseReservationDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(f => f.Id == request.ReservationId)
            ?? throw new NotFoundException(nameof(request.ReservationId), request.ReservationId);    
    }
}
