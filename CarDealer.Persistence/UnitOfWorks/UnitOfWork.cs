using CarDealer.Application.Interfaces.UnitOfWorks;
using CarDealer.Persistence.Context;

namespace CarDealer.Persistence.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    private readonly CarDealerDbContext _context;

    public UnitOfWork(CarDealerDbContext context)
    {
        _context = context;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => await _context.SaveChangesAsync(cancellationToken);
    public void Dispose() => _context.Dispose();
}