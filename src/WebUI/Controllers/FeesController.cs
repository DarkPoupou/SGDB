using CleanArchitecture.Application.Fees.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers;
public class FeesController : ApiControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<FeeDto>> GetFees()
    {
        return await Mediator.Send(new GetFeesQuery());
    }
    [HttpGet("depotId")]
    public async Task<IEnumerable<FeeDto>> GetFees(int depotId)
    {
        return await Mediator.Send(new GetFeesByDepotIdQuery() { DepotId = depotId });
    }
    [HttpGet("EnsureExist")]
    public async Task<ActionResult<FeeDto?>> IsFeeBetweenDepots(int depot1Id, int depot2Id)
    {
        return await Mediator.Send(new IsExistingFeeQuery() { Depot1Id = depot1Id, Depot2Id = depot2Id });
    }
}
