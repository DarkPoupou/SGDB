using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Vehicles.Models;

public class BrandDto: IMapFrom<Brand>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
}