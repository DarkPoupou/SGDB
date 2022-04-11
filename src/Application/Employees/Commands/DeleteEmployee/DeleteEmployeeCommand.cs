using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Employees.Commands.DeleteEmployee;
public class DeleteEmployeeCommand: IRequest<bool>
{
    public int EmployeeId { get; set; }
}
public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteEmployeeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == request.EmployeeId) ?? throw new NotFoundException("no employee found with id" + request.EmployeeId);
        var result = _context.Employees.Remove(employee) != null;
        await _context.SaveChangesAsync(cancellationToken);
        return result;
    }
}
