using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Reservations.Models;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Application.Common.Interfaces;
public interface IPriceCalculationService
{
    Task<double> CalculReservationPriceAsync(IPriceReservationCalculModel reservation, double additionalPlanTypeParameter);
    double FeePriceCalcul(bool isCorrectEndDepot, int nbDays, double feePrice, CarNotoriety notoriety);
    double KilometricPriceCalcul(double priceKilometer, double kilometers, CarNotoriety notoriety);
}
