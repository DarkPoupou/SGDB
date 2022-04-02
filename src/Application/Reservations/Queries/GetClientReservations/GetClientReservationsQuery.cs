using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Reservations.Models;
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

    public GetClientReservationsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<IEnumerable<ReservationDto>> Handle(GetClientReservationsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Reservations.Where(r => r.Client.Id == request.ClientId).OrderByDescending(r => r.EndDate)
            .ProjectTo<ReservationDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }
}
