using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Fees.Queries;

public class FeeDto: IMapFrom<Fee>
{
    public int Id { get; set; }
    public int Depot1Id { get; set; }
    public int Depot2Id { get; set; }
    public double Price { get; set; }
}