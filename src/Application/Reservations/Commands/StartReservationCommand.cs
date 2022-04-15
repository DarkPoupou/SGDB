using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.Reservations.Commands;
public class StartReservationCommand: IRequest<bool>
{
    public int ReservationId { get; set; }
}
public class StartReservationCommandHandler : IRequestHandler<StartReservationCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public StartReservationCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<bool> Handle(StartReservationCommand request, CancellationToken cancellationToken)
    {
        var reservation = await _context.Reservations.FindAsync(request.ReservationId) ?? throw new NotFoundException(nameof(request.ReservationId), request.ReservationId);
        if ((int)reservation.ReservationStatus > 2)
            throw new InvalidOperationException($"you can't start a reservation with status: {reservation.ReservationStatus}");
        
        reservation.ReservationStatus = Domain.Enums.ReservationStatus.Pending;
        return await _context.SaveChangesAsync(cancellationToken) > 0;
    }
}
