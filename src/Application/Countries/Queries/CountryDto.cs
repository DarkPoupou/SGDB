using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Countries.Queries;

public class CountryDto: IMapFrom<Country>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double KilometerPrice { get; set; }
}