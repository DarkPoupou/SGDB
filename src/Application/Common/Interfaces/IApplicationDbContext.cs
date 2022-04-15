using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }
    DbSet<Employee> Employees { get; }
    DbSet<Role> Roles { get; }
    DbSet<Reservation> Reservations { get; }
    DbSet<Client> Clients { get; }
    DbSet<Vehicle> Vehicles { get; }
    DbSet<Plan> Plans { get; }  
    DbSet<Brand> Brands { get; }
    DbSet<Depot> Depots { get; }
    DbSet<Country> Countries { get; }
    DbSet<Fee> Fees { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
