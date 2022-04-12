using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Application.Depots.Models;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Application.Reservations.Models;
public class PlanDto : IMapFrom<Plan>
{
    public int Id { get; set; }
    public double BonusRate { get; set; }
    public PlanType PlanType { get; set; }
    public DepotDto StartDepot { get; set; }
    public int StartDepotId { get; set; }
    public DepotDto EndDepot { get; set; }
    public int EndDepotId { get; set; }
    public double? KilometerPrice { get; set; }
}
