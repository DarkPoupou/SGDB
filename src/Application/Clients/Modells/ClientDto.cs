using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Clients.Modells;
public class ClientDto: IMapFrom<Client>
{
    public int Id { get; set; }
    public string LastName { get; set; }
    public string Firstname { get; set; }
    public string Email { get; set; }
}
