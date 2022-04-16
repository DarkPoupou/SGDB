using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Helpers;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Enums;
using FluentValidation;

namespace CleanArchitecture.Application.Reservations.Commands;
public class ReserveVehicleCommandValidator: AbstractValidator<ReserveVehicleCommand>
{
    public ReserveVehicleCommandValidator(IDepotService depotService, IApplicationDbContext context)
    {
        RuleFor(x => x.PlanType).NotNull().NotEmpty().IsInEnum();
        RuleFor(x => x.VehicleId).GreatherThanWithMessage(0);
        RuleFor(x => x.StartDepotId).GreatherThanWithMessage(0);
        RuleFor(x => x.EndDepotId.Value).GreatherThanWithMessage(0).When(x => x.PlanType == PlanType.Fee);        
        RuleFor(x => x).MustAsync(async (x, CancellationToken) => await depotService.IsFeeExist(x.StartDepotId, x.EndDepotId.Value)).When(x => x.PlanType == PlanType.Fee);
    }
}
