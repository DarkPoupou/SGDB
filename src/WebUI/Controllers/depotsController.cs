using CleanArchitecture.Application.Depots.Models;
using CleanArchitecture.Application.Depots.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers;
public class DepotsController : ApiControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<DepotDto>> GetDepots()
    {
        return await Mediator.Send(new GetdepotsQuery());
    }
    [HttpGet("byId")]
    public async Task<ActionResult<DepotDto>> GetDepotById(int depotId)
    {
        return await Mediator.Send(new GetDepotByIdQuery() { DepotId = depotId });
    }
}
