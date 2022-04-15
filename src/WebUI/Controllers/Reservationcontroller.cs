using CleanArchitecture.Application.Reservations.Commands;
using CleanArchitecture.Application.Reservations.Models;
using CleanArchitecture.Application.Reservations.Queries.GetClientReservations;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers;
public class ReservationController : ApiControllerBase
{
    [HttpGet("Id")]
    public async Task<IEnumerable<ReservationDto>> GetReservationsbyClientId(int clientId)
    {
        return await Mediator.Send(new GetClientReservationsQuery { ClientId = clientId });
    }
    [HttpPost()]
    public async Task<ActionResult<bool>> ReserveVehicle(ReserveVehicleCommand command)
    {
        return await Mediator.Send(command);
    }
    [HttpGet("close")]
    public async Task<ActionResult<CloseReservationDto>> CloseReservation(int reservationId, int NbKilometers = 0)
    {
        return await Mediator.Send(new CloseReservationCommand { NbKilometers = NbKilometers, ReservationId = reservationId });
    }
    [HttpPut("start")]
    public async Task<ActionResult<bool>> StartReservation(int reservationId)
    {
        return await Mediator.Send(new StartReservationCommand { ReservationId = reservationId });
    }
}
