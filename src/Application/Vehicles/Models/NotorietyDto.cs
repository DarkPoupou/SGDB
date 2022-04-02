using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Vehicles.Models;

public class NotorietyDto: IMapFrom<Notoriety>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Coefficient { get; set; }
}