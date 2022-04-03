using CleanArchitecture.Application.Clients.Modells;
using CleanArchitecture.Application.Clients.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers;
public class ClientsController : ApiControllerBase
{
    public async Task<IEnumerable<ClientDto>> GetClients()
    {
        return await Mediator.Send(new GetClientsQuery());
    }
}
