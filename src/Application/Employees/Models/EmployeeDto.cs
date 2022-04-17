using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Employees.Models;
public class EmployeeDto: IMapFrom<Employee>
{
    public int Id { get; set; }
    public string Lastname { get; set; }
    public string Firstname { get; set; }
    public string Email { get; set; }
}
