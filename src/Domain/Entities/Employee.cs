using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities;
public class Employee
{
    public int Id { get; set; }
    public string LastName { get; set; }
    public string Firstname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; }
    public int RoleId { get; set; } = 2;
}
