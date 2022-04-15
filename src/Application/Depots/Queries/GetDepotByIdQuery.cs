using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Depots.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Depots.Queries;
public class GetDepotByIdQuery: IRequest<DepotDto>
{
    public int DepotId { get; set; }
}
public class GetDepotByIdQueryHandler : IRequestHandler<GetDepotByIdQuery, DepotDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetDepotByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<DepotDto> Handle(GetDepotByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.Depots.ProjectTo<DepotDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(d => d.Id == request.DepotId)
            ?? throw new NotFoundException(nameof(request.DepotId), request.DepotId);
    }
}
