using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Depots.Models;

namespace CleanArchitecture.Application.Common.Interfaces;
public interface IDepotService
{
    public bool IsFeesDepot1First(ISimpleDepotComparableModel depot1, ISimpleDepotComparableModel depot2);
    public Task<bool> IsFeeExist(int depot1Id, int depot2Id);    
}
