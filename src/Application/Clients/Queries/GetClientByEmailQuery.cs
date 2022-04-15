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
public class GetClientByEmailQuery: IRequest<ClientDto>
{
    public string Email { get; set; }
}
public class GetClientByEmailQueryHandler : IRequestHandler<GetClientByEmailQuery, ClientDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetClientByEmailQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ClientDto> Handle(GetClientByEmailQuery request, CancellationToken cancellationToken)
    {
        return await _context.Clients.ProjectTo<ClientDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(c => c.Email == request.Email)
            ?? throw new NotFoundException(nameof(request.Email), request.Email);
    }
}
