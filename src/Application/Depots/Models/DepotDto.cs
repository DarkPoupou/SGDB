using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.Configuration.Annotations;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Depots.Models;
public class DepotDto: IMapFrom<Depot>
{
    public int Id { get; set; }    
    public string Name { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public CountryNameDto Country { get; set; }
    [Ignore]
    public int VehiclesCount { get; set; }
}
