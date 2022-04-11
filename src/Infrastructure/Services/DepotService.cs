using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Depots.Models;

namespace CleanArchitecture.Infrastructure.Services;
public class DepotService : IDepotService
{
    public bool IsFeesDepot1First(ISimpleDepotComparableModel depot1, ISimpleDepotComparableModel depot2)
    {
        int length = Math.Min(depot1.City.Length, depot2.City.Length);
        bool? result = null;
        for (int i = 0; result != null && i < length; i++)
        {
            if (depot1.City[i] < depot2.City[i])
                result = true;

            else if (depot1.City[i] > depot2.City[i])
                result = false;
        }
        return result ?? false;
    }
}
