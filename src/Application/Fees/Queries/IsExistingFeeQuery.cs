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

namespace CleanArchitecture.Application.Fees.Queries;
public class IsExistingFeeQuery: IRequest<FeeDto?>
{
    public int Depot1Id { get; set; }
    public int Depot2Id { get; set; }
}
public class IsExistingFeeQueryHandler : IRequestHandler<IsExistingFeeQuery, FeeDto?>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IDepotService _depotService;

    public IsExistingFeeQueryHandler(IApplicationDbContext context, IMapper mapper, IDepotService depotService)
    {
        _context = context;
        _mapper = mapper;
        _depotService = depotService;
    }

    public async Task<FeeDto?> Handle(IsExistingFeeQuery request, CancellationToken cancellationToken)
    {
        var depot1 = await _context.Depots.AsNoTracking().ProjectTo<SimpleDepotComparableModel>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(d => d.Id == request.Depot1Id) ?? throw new NotFoundException(nameof(request.Depot1Id));
        var depot2 = await _context.Depots.AsNoTracking().ProjectTo<SimpleDepotComparableModel>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(d => d.Id == request.Depot2Id) ?? throw new NotFoundException(nameof(request.Depot2Id));
       
        if(!_depotService.IsFeesDepot1First(depot1, depot2))
            (depot1, depot2) = (depot2, depot1);

        return await _context.Fees.AsNoTracking().ProjectTo<FeeDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(f => f.Depot1Id == depot1.Id && f.Depot2Id == depot2.Id);
    }
}
