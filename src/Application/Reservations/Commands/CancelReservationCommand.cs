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
public class CancelReservationCommand: IRequest<bool>
{
    public int ReersvationId { get; set; }
}
public class CancelReservationCommandHandler : IRequestHandler<CancelReservationCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public CancelReservationCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<bool> Handle(CancelReservationCommand request, CancellationToken cancellationToken)
    {
        var reservation = await _context.Reservations.FindAsync(request.ReersvationId)
            ?? throw new NotFoundException();

        if(reservation.ReservationStatus != ReservationStatus.Booked)
            return false;

        reservation.ReservationStatus = ReservationStatus.Cancelled;

        return await _context.SaveChangesAsync(cancellationToken) > 0;
    }
}
