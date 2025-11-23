using CarDealer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarDealer.Persistence.Context;

public class CarDealerDbContext : DbContext
{
    public CarDealerDbContext(DbContextOptions<CarDealerDbContext> opt) : base(opt)
    {
    }

    public DbSet<Car> Cars { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}