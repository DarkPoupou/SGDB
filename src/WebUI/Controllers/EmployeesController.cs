using CleanArchitecture.Application.Employees.Commands.CreateEmployee;
using CleanArchitecture.Application.Employees.Commands.DeleteEmployee;
using CleanArchitecture.Application.Employees.Commands.UpdateEmployee;
using CleanArchitecture.Application.Employees.Models;
using CleanArchitecture.Application.Employees.Queries.GetEmployeeById;
using CleanArchitecture.Application.Employees.Queries.GetEmployees;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers;
public class EmployeesController : ApiControllerBase
{
    [HttpGet("Id")]
    public async Task<ActionResult<EmployeeDto>> GetEmployeeById(int employeeId)
    {
        return await Mediator.Send(new GetEmployeeByIdQuery { EmployeeId = employeeId });
    }
    [HttpGet]
    public async Task<IEnumerable<EmployeeRoleDto>> GetEmployees()
    {
        return await Mediator.Send(new GetEmployeesQuery());
    }
    [HttpPost]
    public async Task<ActionResult<bool>> CreateEmployee(CreateEmployeeCommand command)
    {
        return await Mediator.Send(command);
    }
    [HttpDelete("delete")]
    public async Task<ActionResult<bool>> DeleteEmployee(int id)
    {
        return await Mediator.Send(new DeleteEmployeeCommand { EmployeeId = id });
    }
    [HttpPut]
    public async Task<ActionResult> UpdateEmployee(UpdateEmployeeCommand command)
    {
        await Mediator.Send(command);
        return NoContent();
    }
}
