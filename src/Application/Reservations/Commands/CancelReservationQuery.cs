using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Enums;
using MediatR;

namespace CleanArchitecture.Application.Reservations.Commands;
public class CancelReservationQuery: IRequest<bool>
{
    public int ReersvationId { get; set; }
}
public class CancelReservationQueryHandler : IRequestHandler<CancelReservationQuery, bool>
{
    private readonly IApplicationDbContext _context;

    public CancelReservationQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<bool> Handle(CancelReservationQuery request, CancellationToken cancellationToken)
    {
        var reservation = await _context.Reservations.FindAsync(request.ReersvationId)
            ?? throw new NotFoundException();

        if(reservation.ReservationStatus != ReservationStatus.Booked)
            return false;

        reservation.ReservationStatus = ReservationStatus.Cancelled;

        return await _context.SaveChangesAsync(cancellationToken) > 0;
    }
}
