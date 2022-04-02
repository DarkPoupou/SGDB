using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Vehicles.Models;
using CleanArchitecture.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Vehicles.Queries.GetavailableVehicles;
public class GetavailableVehiclesQuery: IRequest<IEnumerable<VehicleDto>>
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int DepotId { get; set; }
}
public class GetavailableVehiclesQueryHandler : IRequestHandler<GetavailableVehiclesQuery, IEnumerable<VehicleDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetavailableVehiclesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<IEnumerable<VehicleDto>> Handle(GetavailableVehiclesQuery request, CancellationToken cancellationToken)
    {
        var depot = await _context.Depots.FirstOrDefaultAsync(d => d.Id == request.DepotId);
        return await _context.Vehicles.Where(v => (v.Reservation.ReservationStatus == ReservationStatus.Cancelled || v.Reservation.ReservationStatus == ReservationStatus.Comlpeted)
            || (request.StartDate.Date > v.Reservation.StartDate.Date && request.StartDate.Date > v.Reservation.EndDate.Date)
            || (request.StartDate.Date < v.Reservation.StartDate.Date && request.EndDate.Date < v.Reservation.StartDate.Date)
            && v.Depot.Id == request.DepotId)
        .ProjectTo<VehicleDto>(_mapper.ConfigurationProvider)
        .ToListAsync(cancellationToken);
    }
}
