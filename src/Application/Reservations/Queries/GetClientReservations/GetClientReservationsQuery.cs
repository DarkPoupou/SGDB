using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Reservations.Models;
using CleanArchitecture.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Reservations.Queries.GetClientReservations;
public class GetClientReservationsQuery:IRequest<IEnumerable<ReservationDto>>
{
    public int ClientId { get; set; }
}
public class GetClientReservationsQueryHandler : IRequestHandler<GetClientReservationsQuery, IEnumerable<ReservationDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IPriceCalculationService _priceCalculation;

    public GetClientReservationsQueryHandler(IApplicationDbContext context, IMapper mapper, IPriceCalculationService priceCalculation)
    {
        _context = context;
        _mapper = mapper;
        _priceCalculation = priceCalculation;
    }
    public async Task<IEnumerable<ReservationDto>> Handle(GetClientReservationsQuery request, CancellationToken cancellationToken)
    {
        var r = await _context.Reservations.Where(r => r.Client.Id == request.ClientId).OrderByDescending(r => r.EndDate)
            .ProjectTo<ReservationDto>(_mapper.ConfigurationProvider)
            .ToListAsync();

        foreach (var reservation in r)
        {
            if(reservation.Price == 0 && reservation.PlanPlanType == PlanType.Fee)
            {
                reservation.Price = await _priceCalculation.CalculReservationPriceAsync(reservation, reservation.PlanEndDepotId);
            }
        }
        return r;
    }
}
