using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.Reservations.Queries;
public class CancellReservationQuery: IRequest<bool>
{
    public int ReservationId { get; set; }

}
public class CancellReservationQueryHandler : IRequestHandler<CancellReservationQuery, bool>
{
    public CancellReservationQueryHandler(IApplicationDbContext context)
    {

    }
    public Task<bool> Handle(CancellReservationQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
