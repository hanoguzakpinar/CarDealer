using CarDealer.Application.Interfaces.Repositories;
using CarDealer.Domain.Common;
using CarDealer.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarDealer.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly CarDealerDbContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(CarDealerDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task AddAsync(T entity, CancellationToken cancellationToken = default) => await _dbSet.AddAsync(entity, cancellationToken);
    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default) => await _dbSet.AsNoTracking().ToListAsync(cancellationToken);
    public async Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) => await _dbSet.FindAsync(id, cancellationToken);
    public void Delete(T entity) => _dbSet.Remove(entity);
    public void Update(T entity) => _dbSet.Update(entity);
}