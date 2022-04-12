using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Depots.Models;

using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Services;
public class DepotService : IDepotService
{
    private readonly IApplicationDbContext _contex;

    public DepotService(IApplicationDbContext contex)
    {
        _contex = contex;
    }
    public async Task<bool> IsFeeExist(int depot1Id, int depot2Id)
    {
        return await _contex.Fees.AnyAsync(f => f.Depot1Id == depot1Id && f.Depot2Id == depot2Id || f.Depot1Id == depot2Id && f.Depot2Id == depot1Id);
    }

    public bool IsFeesDepot1First(ISimpleDepotComparableModel depot1, ISimpleDepotComparableModel depot2)
    {
        int length = Math.Min(depot1.City.Length, depot2.City.Length);
        
        for (int i = 0;i < length; i++)
        {
            if (depot1.City[i] < depot2.City[i])
                return true;

            else if (depot1.City[i] > depot2.City[i])
                return false;
        }
        return false;
    }
}
