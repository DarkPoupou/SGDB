using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Vehicles.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Vehicles.Queries;
public class GetVehiclesByDepotQuery: IRequest<IEnumerable<VehicleDto>>
{
    public int DepotId { get; set; }
}
public class GetVehiclesByDepotQueryHandler : IRequestHandler<GetVehiclesByDepotQuery, IEnumerable<VehicleDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetVehiclesByDepotQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<IEnumerable<VehicleDto>> Handle(GetVehiclesByDepotQuery request, CancellationToken cancellationToken)
    {
        return await _context.Vehicles.Where(v => v.DepotId == request.DepotId).ProjectTo<VehicleDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
    }
}
