using CleanArchitecture.Application.Vehicles.Commands;
using CleanArchitecture.Application.Vehicles.Models;
using CleanArchitecture.Application.Vehicles.Queries;
using CleanArchitecture.Application.Vehicles.Queries.GetavailableVehicles;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers;
public class VehiclesController : ApiControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<VehicleDto>> GetavailableVehicles(DateTime startDate, DateTime endate, int depotId)
    {
        return await Mediator.Send(new GetavailableVehiclesQuery { DepotId = depotId, StartDate = startDate, EndDate = endate });
    }
    [HttpGet("depot")]
    public async Task<IEnumerable<VehicleDto>> GetavailableVehicles(int depotId)
    {
        return await Mediator.Send(new GetVehiclesByDepotQuery { DepotId = depotId });
    }
    [HttpPost]
    public async Task<ActionResult<bool>> AddNewVehicle(AddVehicleCommand command)
    {
        return await Mediator.Send(command);
    }
}
