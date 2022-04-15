using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Helpers;
using FluentValidation;

namespace CleanArchitecture.Application.Reservations.Commands;
public class CloseReservationCommandValidator: AbstractValidator<CloseReservationCommand>
{
    public CloseReservationCommandValidator()
    {
        RuleFor(c => c.ReservationId).GreatherThanWithMessage(0);
    }
}
