namespace CarDealer.Application.Interfaces.UnitOfWorks;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
}