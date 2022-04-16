using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Application.Common.Helpers;
public static class IEnumerableHelper
{
    public static bool HasBookedReservation(this IEnumerable<Reservation> source, DateTime startDate, DateTime endDate)
    {
        return source.Any(r => ((r.ReservationStatus == ReservationStatus.Booked || r.ReservationStatus == ReservationStatus.Pending)
            && (r.EndDate.Date >= DateTime.Now.Date)
            && !(startDate > r.EndDate || endDate < r.StartDate)));            
    }
}
