using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Enums;
using MediatR;

namespace CleanArchitecture.Application.Reservations.Commands;
public class ReserveVehicleCommand: IRequest<bool>
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public PlanType PlanType { get; set; }
    public int VehicleId { get; set; }
    public int StartDepotId { get; set; }
    public int? EndDepotId { get; set; }
    public int ClientId { get; set; }
}
public class ReserveVehicleCommandHandler : IRequestHandler<ReserveVehicleCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public ReserveVehicleCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public Task<bool> Handle(ReserveVehicleCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
