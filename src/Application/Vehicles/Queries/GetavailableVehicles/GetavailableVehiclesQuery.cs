using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Helpers;
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
    private readonly IDateTime _dateTime;

    public GetavailableVehiclesQueryHandler(IApplicationDbContext context, IMapper mapper, IDateTime dateTime)
    {
        _context = context;
        _mapper = mapper;
        _dateTime = dateTime;
    }
    public async Task<IEnumerable<VehicleDto>> Handle(GetavailableVehiclesQuery request, CancellationToken cancellationToken)
    {
        return await _context.Vehicles.Where(v => v.DepotId == request.DepotId && 
            !v.Reservations.HasBookedReservation(request.StartDate, request.EndDate))
        .ProjectTo<VehicleDto>(_mapper.ConfigurationProvider)
        .ToListAsync(cancellationToken);
    }
}
