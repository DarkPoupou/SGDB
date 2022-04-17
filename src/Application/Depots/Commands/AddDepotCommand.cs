using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Depots.Commands;
public class AddDepotCommand: IRequest<bool>
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public int CountryId { get; set; }
}
public class AddDepotCommandHandler : IRequestHandler<AddDepotCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public AddDepotCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<bool> Handle(AddDepotCommand request, CancellationToken cancellationToken)
    {
        Depot depot = new() { Name = request.Name, Address = request.Address, City = request.City };
        Country country = await _context.Countries.FindAsync(request.CountryId) ?? throw new NotFoundException(nameof(country), request.CountryId);

        depot.Country = country;
        await _context.Depots.AddAsync(depot);
        return await _context.SaveChangesAsync(cancellationToken) > 0;
    }
}
