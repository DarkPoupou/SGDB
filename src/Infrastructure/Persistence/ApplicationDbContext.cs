using System.Reflection;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CleanArchitecture.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{

    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options) : base(options){ }

    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<Reservation> Reservations => Set<Reservation>();
    public DbSet<Client> Clients => Set<Client>();
    public DbSet<Vehicle> Vehicles => Set<Vehicle>();
    public DbSet<Plan> Plans => Set<Plan>();
    public DbSet<Brand> Brands => Set<Brand>();
    public DbSet<Depot> Depots => Set<Depot>();
    public DbSet<Country> Countries => Set<Country>();
    public DbSet<Fee> Fees => Set<Fee>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


        base.OnModelCreating(builder);
        foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}
