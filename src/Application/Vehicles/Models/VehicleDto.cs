using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Vehicles.Models;
public class VehicleDto: IMapFrom<Vehicle>
{
    public int Id { get; set; }
    public string Immatriculation { get; set; }
    public NotorietyDto Notoriety { get; set; }
    public BrandDto Brand { get; set; }    
}
