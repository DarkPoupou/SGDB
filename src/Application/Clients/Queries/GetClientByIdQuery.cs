using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Clients.Modells;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Clients.Queries;
public class GetClientByIdQuery: IRequest<ClientDto>
{
    public int ClientId { get; set; }
}
public class GetClientByIdQueryHandler : IRequestHandler<GetClientByIdQuery, ClientDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetClientByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ClientDto> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.Clients.ProjectTo<ClientDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync()
            ?? throw new NotFoundException();
    }
}
