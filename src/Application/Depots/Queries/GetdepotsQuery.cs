using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Depots.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Depots.Queries;
public class GetdepotsQuery: IRequest<IEnumerable<DepotDto>>
{
}
public class GetdepotsQueryHandler : IRequestHandler<GetdepotsQuery, IEnumerable<DepotDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetdepotsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<IEnumerable<DepotDto>> Handle(GetdepotsQuery request, CancellationToken cancellationToken)
    {
        var depots = await _context.Depots.ProjectTo<DepotDto>(_mapper.ConfigurationProvider).ToListAsync();
        foreach (var depot in depots)
        {
            depot.VehiclesCount =  _context.Depots.FindAsync(depot.Id).Result?.Vehicle?.Count ?? 0;
        }
        return depots;
    }
}
