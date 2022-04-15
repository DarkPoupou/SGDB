using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces;
using FluentValidation;

namespace CleanArchitecture.Application.Vehicles.Queries.GetavailableVehicles;
public class GetavailableVehiclesQueryValidator: AbstractValidator<GetavailableVehiclesQuery>
{
    public GetavailableVehiclesQueryValidator(IDateTime dateTime)
    {
        RuleFor(x => x.StartDate).NotNull().GreaterThanOrEqualTo(dateTime.Now).LessThanOrEqualTo(x => x.EndDate);
        RuleFor(x => x.EndDate).GreaterThanOrEqualTo(x => x.EndDate).When(x => x.EndDate != null);
    }
}
