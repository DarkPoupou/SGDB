using CleanArchitecture.Application.Vehicles.Commands;
using CleanArchitecture.Application.Vehicles.Models;
using CleanArchitecture.Application.Vehicles.Queries;
using CleanArchitecture.Application.Vehicles.Queries.GetavailableVehicles;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers;
public class VehiclesController : ApiControllerBase
{
    [HttpGet("available")]
    public async Task<IEnumerable<VehicleDto>> GetavailableVehicles(DateTime startDate, DateTime endate, int depotId)
    {
        return await Mediator.Send(new GetavailableVehiclesQuery { DepotId = depotId, StartDate = startDate, EndDate = endate });
    }
    [HttpGet("depot")]
    public async Task<IEnumerable<VehicleDto>> GetVehiclesByDepot(int depotId)
    {
        return await Mediator.Send(new GetVehiclesByDepotQuery { DepotId = depotId });
    }
    [HttpGet()]
    public async Task<IEnumerable<VehicleDto>> GetVehicles()
    {
        return await Mediator.Send(new GetVehiclesByDepotQuery { DepotId = 0 });
    }
    [HttpPost]
    public async Task<ActionResult<bool>> AddNewVehicle(AddVehicleCommand command)
    {
        return await Mediator.Send(command);
    }
}
