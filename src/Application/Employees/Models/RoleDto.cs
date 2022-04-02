using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Employees.Models;

public class RoleDto: IMapFrom<Role>
{
    public string Name { get; set; }
}