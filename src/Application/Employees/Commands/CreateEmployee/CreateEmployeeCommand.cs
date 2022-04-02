using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Employees.Commands.CreateEmployee;
public class CreateEmployeeCommand: IRequest<bool>
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Mail { get; set; }
    public string Password { get; set; }
}
public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public CreateEmployeeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<bool> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        Employee employee = new()
        {
            Email = request.Mail,
            Firstname = request.Firstname,
            LastName = request.Lastname,
            Password = request.Password,
        };

        var result = await _context.Employees.AddAsync(employee);
        await _context.SaveChangesAsync(cancellationToken);
        return result != null;
    }
}
