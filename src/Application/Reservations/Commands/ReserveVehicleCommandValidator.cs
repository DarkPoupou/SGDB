using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Enums;
using FluentValidation;

namespace CleanArchitecture.Application.Reservations.Commands;
public class ReserveVehicleCommandValidator: AbstractValidator<ReserveVehicleCommand>
{
    public ReserveVehicleCommandValidator(IDepotService depotService)
    {
        RuleFor(x => x.VehicleId).GreaterThan(0);
        RuleFor(x => x.StartDepotId).GreaterThan(0);
        RuleFor(x => x.EndDepotId.Value).GreaterThan(0).When(x => x.PlanType == PlanType.Fee);
        RuleFor(x => x).MustAsync(async (x, CancellationToken) => await depotService.IsFeeExist(x.StartDepotId, x.EndDepotId.Value)).When(x => x.PlanType == PlanType.Fee);
    }
}
