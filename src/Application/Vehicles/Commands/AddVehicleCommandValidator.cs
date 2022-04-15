using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Helpers;
using CleanArchitecture.Domain.Enums;
using FluentValidation;

namespace CleanArchitecture.Application.Vehicles.Commands;
public class AddVehicleCommandValidator: AbstractValidator<AddVehicleCommand>
{
    public AddVehicleCommandValidator()
    {
        RuleFor(x => x.Model).NotEmpty();
        RuleFor(x => x.CarNotoriety).NotEmpty();
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Immatriculation).NotEmpty();
        RuleFor(x => x.DepotId).GreatherThanWithMessage(0);
    }
}
