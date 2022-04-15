using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Enums;
using MediatR;

namespace CleanArchitecture.Application.Vehicles.Commands;
public class AddVehicleCommand: IRequest<bool>
{
    public string Immatriculation { get; set; }
    public int DepotId { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public CarNotoriety CarNotoriety { get; set; }
    public double Kilometer { get; set; }
}
public class AddVehicleCommandHandler : IRequestHandler<AddVehicleCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public AddVehicleCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<bool> Handle(AddVehicleCommand request, CancellationToken cancellationToken)
    {
        Brand brand = new()
        {
            Model = request.Model,
            Name = request.Name,
            Notoriety = request.CarNotoriety
        };
        Vehicle vehicle = new()
        {
            Brand = brand,
            Immatriculation = request.Immatriculation,
            DepotId = request.DepotId,
            Kilometer = request.Kilometer
        };
        var r = await _context.Vehicles.AddAsync(vehicle);
        return await _context.SaveChangesAsync(cancellationToken) > 0;
    }
}
