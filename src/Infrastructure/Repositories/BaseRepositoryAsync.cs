using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Core.Models;
using MyApp.Domain.Core.Repositories;
using MyApp.Domain.Core.Specifications;
using MyApp.Infrastructure.Data;

namespace MyApp.Infrastructure.Repositories;

public class BaseRepositoryAsync<TEntity> : IBaseRepositoryAsync<TEntity> where TEntity : BaseEntity
{
    private readonly AppDbContext _dbContext;

    public BaseRepositoryAsync(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken ctk = default)
    {
        return await _dbContext.Set<TEntity>().FindAsync(new object[] { id }, cancellationToken: ctk);
    }

    public async Task<IList<TEntity>> ListAllAsync()
    {
        return await _dbContext.Set<TEntity>().ToListAsync();
    }

    public async Task<List<TEntity?>> ListAsync(ISpecification<TEntity> spec, CancellationToken ctk = default)
    {
        return await ApplySpecification(spec).ToListAsync(ctk);
    }

    public async Task<TEntity?> FirstOrDefaultAsync(ISpecification<TEntity> spec, CancellationToken ctk = default)
    {
        return await ApplySpecification(spec).FirstOrDefaultAsync(ctk);
    }

    public async Task<int> CountAsync(ISpecification<TEntity> spec)
    {
        return await ApplySpecification(spec).CountAsync();
    }

    public async Task<TEntity> AddAsync(TEntity entity, CancellationToken ctk = default)
    {
        await _dbContext.Set<TEntity>().AddAsync(entity, ctk);
        return entity;
    }

    public void Update(TEntity entity)
    {
        _dbContext.Set<TEntity>().Update(entity);
    }

    public void Delete(TEntity entity)
    {
        _dbContext.Set<TEntity>().Remove(entity);
    }

    private IQueryable<TEntity?> ApplySpecification(ISpecification<TEntity> spec)
    {
        return SpecificationEvaluator<TEntity>.GetQuery(_dbContext.Set<TEntity>().AsQueryable(), spec);
    }
}