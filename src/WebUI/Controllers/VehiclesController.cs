using CleanArchitecture.Application.Vehicles.Models;
using CleanArchitecture.Application.Vehicles.Queries.GetavailableVehicles;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers;
public class VehiclesController : ApiControllerBase
{
    public async Task<IEnumerable<VehicleDto>> GetavailableVehicles(DateTime startDate, DateTime endate, int depotId)
    {
        return await Mediator.Send(new GetavailableVehiclesQuery { DepotId = depotId, StartDate = startDate, EndDate = endate });
    }
}
