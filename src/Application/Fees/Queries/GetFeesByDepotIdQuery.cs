using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Fees.Queries;
public class GetFeesByDepotIdQuery: IRequest<IEnumerable<FeeDto>>
{
    public int DepotId { get; set; }
}
public class GetFeesByDepotIdQueryHandler : IRequestHandler<GetFeesByDepotIdQuery, IEnumerable<FeeDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetFeesByDepotIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<IEnumerable<FeeDto>> Handle(GetFeesByDepotIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.Fees.ProjectTo<FeeDto>(_mapper.ConfigurationProvider).Where(f => f.Depot1Id == request.DepotId || f.Depot2Id == request.DepotId).ToListAsync();
    }
}
