using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Vehicles.Models;
using CleanArchitecture.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Vehicles.Queries.GetavailableVehicles;
public class GetavailableVehiclesQuery: IRequest<IEnumerable<VehicleDto>>
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int DepotId { get; set; }
}
public class GetavailableVehiclesQueryHandler : IRequestHandler<GetavailableVehiclesQuery, IEnumerable<VehicleDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IDateTime _dateTime;

    public GetavailableVehiclesQueryHandler(IApplicationDbContext context, IMapper mapper, IDateTime dateTime)
    {
        _context = context;
        _mapper = mapper;
        _dateTime = dateTime;
    }
    public async Task<IEnumerable<VehicleDto>> Handle(GetavailableVehiclesQuery request, CancellationToken cancellationToken)
    {
        return await _context.Vehicles.Where(v => !v.Reservations.Any(
            r => ((r.EndDate.Date >= DateTime.Now.Date)
            && !(request.StartDate > r.EndDate || request.EndDate < r.StartDate)))
            && v.DepotId == request.DepotId)
        .ProjectTo<VehicleDto>(_mapper.ConfigurationProvider)
        .ToListAsync(cancellationToken);

        //return await _context.Vehicles.Where(v =>  !v.Reservations.Any(
        //    r => ((request.StartDate < r.StartDate && request.EndDate <= r.EndDate)
        //         || (request.StartDate > r.StartDate && request.EndDate > r.EndDate && request.StartDate < r.EndDate)
        //         || (request.StartDate >= r.StartDate && request.EndDate <= r.EndDate)
        //         || (request.StartDate < r.StartDate && request.EndDate > r.EndDate))) 
        //    && v.DepotId == request.DepotId)
        //.ProjectTo<VehicleDto>(_mapper.ConfigurationProvider)
        //.ToListAsync(cancellationToken);
        //return await _context.Reservations.Where(r => 
        //        !((request.StartDate < r.StartDate && request.EndDate <= r.EndDate)
        //         || (request.StartDate > r.StartDate && request.EndDate > r.EndDate && request.StartDate < r.EndDate)
        //         || (request.StartDate >= r.StartDate && request.EndDate <= r.EndDate)
        //         || (request.StartDate < r.StartDate && request.EndDate > r.EndDate)) 
        //     && r.Plan.StartDepotId == request.DepotId)
        //.Select(r => r.Vehicle)
        //.ProjectTo<VehicleDto>(_mapper.ConfigurationProvider).Distinct()
        //.ToListAsync(cancellationToken);
        ///*.Select(r => r.Vehicle);*/
        //var depot = await _context.Depots.FirstOrDefaultAsync(d => d.Id == request.DepotId);
        //return await _context.Vehicles.Where(v => (v.Reservation.ReservationStatus == ReservationStatus.Cancelled || v.Reservation.ReservationStatus == ReservationStatus.Comlpeted)
        //    || (request.StartDate.Date > v.Reservation.StartDate.Date && request.StartDate.Date > v.Reservation.EndDate.Date)
        //    || (request.StartDate.Date < v.Reservation.StartDate.Date && request.EndDate.Date < v.Reservation.StartDate.Date)
        //    && v.Depot.Id == request.DepotId)
        //.ProjectTo<VehicleDto>(_mapper.ConfigurationProvider)
        //.ToListAsync(cancellationToken);
    }
}
