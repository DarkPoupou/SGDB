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
public class GetFeesQuery: IRequest<IEnumerable<FeeDto>>
{
}
public class GetFeesQueryHandler : IRequestHandler<GetFeesQuery, IEnumerable<FeeDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetFeesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<FeeDto>> Handle(GetFeesQuery request, CancellationToken cancellationToken)
    {
        return await _context.Fees.ProjectTo<FeeDto>(_mapper.ConfigurationProvider).ToListAsync();

    }
    
}
