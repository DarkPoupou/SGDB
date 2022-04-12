using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces;

namespace CleanArchitecture.Infrastructure.Services;
public class ReservationCalculService : IReservationCalculService
{
    private readonly IDateTime _dateTime;

    public ReservationCalculService(IDateTime dateTime)
    {
        _dateTime = dateTime;
    }
    public double CalculateBonus(DateTime startDate)
    {
        if (startDate < DateTime.Now)
            throw new ValidationException(nameof(startDate));

        var diff = startDate.Date - _dateTime.Now.Date;
        var nbWeeks = (int)diff.TotalDays / 7 - 1;
        double bonus = 0.05 * nbWeeks;
        bonus = bonus > 0.2 ? 0.2 : bonus;
        return bonus;
    }
}
