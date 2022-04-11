using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Depots.Models;

public interface ISimpleDepotComparableModel
{
    string City { get; set; }
}

public class SimpleDepotComparableModel : IMapFrom<Depot>, ISimpleDepotComparableModel
{
    public int Id { get; set; }
    public string City { get; set; }
}
