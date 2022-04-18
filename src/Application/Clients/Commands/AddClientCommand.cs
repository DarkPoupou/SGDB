using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Clients.Commands;
public class AddClientCommand: IRequest<bool>
{
    public string Lastname { get; set; }
    public string firstname { get; set; }
    public string Email { get; set; }
}
public class AddClientCommandHandler : IRequestHandler<AddClientCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public AddClientCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<bool> Handle(AddClientCommand request, CancellationToken cancellationToken)
    {
        Client client = new() { Email = request.Email, LastName = request.Lastname, Firstname = request.firstname, Password = $"{request.Lastname}.{request.firstname}" };

        _context.Clients.Add(client);
        return await _context.SaveChangesAsync(cancellationToken) > 0;
    }
}
