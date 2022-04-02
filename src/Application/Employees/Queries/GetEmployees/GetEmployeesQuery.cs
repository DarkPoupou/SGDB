using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Employees.Models;
using CleanArchitecture.Application.Employees.Queries.GetEmployeeById;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Employees.Queries.GetEmployees;
public class GetEmployeesQuery: IRequest<IEnumerable<EmployeeRoleDto>>
{
}
public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, IEnumerable<EmployeeRoleDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetEmployeesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<IEnumerable<EmployeeRoleDto>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
    {
        return await _context.Employees.ProjectTo<EmployeeRoleDto>(_mapper.ConfigurationProvider).ToListAsync();
    }
}
