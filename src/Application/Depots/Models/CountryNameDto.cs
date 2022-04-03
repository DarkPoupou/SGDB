using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Depots.Models;

public class CountryNameDto: IMapFrom<Country>
{
    public int Id { get; set; }
    public string Name { get; set; }
}