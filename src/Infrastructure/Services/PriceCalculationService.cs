using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Reservations.Models;
using CleanArchitecture.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Services;
public class PriceCalculationService : IPriceCalculationService
{
    private readonly IApplicationDbContext _context;

    public PriceCalculationService (IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<double> CalculReservationPriceAsync(IPriceReservationCalculModel reservation, double additionalPlanTypeParameter)
    {
        if (reservation.PlanPlanType == PlanType.Kilometric)
            return KilometricPriceCalcul(reservation.PlanKilometerPrice, additionalPlanTypeParameter, reservation.VehicleBrandNotoriety);            
        
        var fee = await _context.Fees.AsNoTracking().FirstOrDefaultAsync(
            f => (f.Depot1Id == reservation.PlanStartDepotId && f.Depot2Id == reservation.PlanEndDepotId)
            || (f.Depot1Id == reservation.PlanEndDepotId && f.Depot2Id == reservation.PlanStartDepotId))
            ?? throw new NotFoundException("no fee found");

        var nbDays = (reservation.EndDate.Date - reservation.StartDate.Date).TotalDays;
        return FeePriceCalcul(additionalPlanTypeParameter == reservation.PlanEndDepotId, (int)nbDays, fee.Price,reservation.VehicleBrandNotoriety);        
    }
    public double FeePriceCalcul(bool isCorrectEndDepot, int nbDays, double feePrice, CarNotoriety notoriety)
        => (isCorrectEndDepot? 0.95 : 1.1) * nbDays * feePrice * CalculCarCoefficient(notoriety);
    public double KilometricPriceCalcul(double priceKilometer, double kilometers, CarNotoriety notoriety)
        => priceKilometer * kilometers * CalculCarCoefficient(notoriety);
    private static double CalculCarCoefficient(CarNotoriety notoriety)
        => Math.Sqrt((int)notoriety);
}
