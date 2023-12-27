using MyApp.Domain.Core.Models;
using MyApp.Domain.Core.Repositories;
using MyApp.Infrastructure.Data;

namespace MyApp.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _dbContext;
    private readonly IDictionary<Type, dynamic> _repositories;

    public UnitOfWork(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        _repositories = new Dictionary<Type, dynamic>();
    }

    public IBaseRepositoryAsync<T> Repository<T>() where T : BaseEntity
    {
        var entityType = typeof(T);

        if (_repositories.TryGetValue(entityType, out var value))
        {
            return value;
        }

        var repositoryType = typeof(BaseRepositoryAsync<>);

        var repository = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _dbContext);

        if (repository == null)
        {
            throw new NullReferenceException("Repository should not be null");
        }

        _repositories.Add(entityType, repository);

        return (IBaseRepositoryAsync<T>)repository;
    }

    public async Task<int> SaveChangesAsync(CancellationToken ctk = default)
    {
        try
        {
            return await _dbContext.SaveChangesAsync(ctk);
        }
        catch (Exception e)
        {
            throw e;
        }
    }


    public async Task RollBackChangesAsync(CancellationToken ctk = default)
    {
        try
        {
            await _dbContext.Database.RollbackTransactionAsync(ctk);
        }
        catch (Exception e)
        {
            throw e;
        }
    }
}