using CleanArchitecture.Application.Employees.Models;
using CleanArchitecture.Application.Roles.Queries;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers;
public class RolesController : ApiControllerBase
{

    public async Task<IEnumerable<RoleDto>> GetRoles()
    {
        return await Mediator.Send(new GetRolesQuery());
    }
}
