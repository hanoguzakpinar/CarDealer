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

    public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);
    public void Delete(T entity) => _dbSet.Remove(entity);
    public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();//AsNoTracking eklenebilir.
    public async Task<T> GetByIdAsync(Guid id) => await _dbSet.FindAsync(id);
    public void Update(T entity) => _dbSet.Update(entity);
}