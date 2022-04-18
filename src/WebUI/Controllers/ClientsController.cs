using CleanArchitecture.Application.Clients.Commands;
using CleanArchitecture.Application.Clients.Modells;
using CleanArchitecture.Application.Clients.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers;
public class ClientsController : ApiControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<ClientDto>> GetClients()
    {
        return await Mediator.Send(new GetClientsQuery());
    }
    [HttpPost]
    public async Task<ActionResult<bool>> CreateClient(AddClientCommand command)
    {
        return await Mediator.Send(command);
    }
    [HttpGet("Email")]
    public async Task<ActionResult<ClientDto>> GetClientByEmail(string email)
    {
        return await Mediator.Send(new GetClientByEmailQuery { Email = email });
    }
    [HttpGet("Id")]
    public async Task<ActionResult<ClientDto>> GetClientById(int clientId)
    {
        return await Mediator.Send(new GetClientByIdQuery { ClientId = clientId});
    }
}
