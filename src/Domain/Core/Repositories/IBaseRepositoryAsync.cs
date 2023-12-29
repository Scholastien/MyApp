using MyApp.Domain.Core.Models;
using MyApp.Domain.Core.Specifications;

namespace MyApp.Domain.Core.Repositories;

public interface IBaseRepositoryAsync<TEntity> where TEntity : BaseEntity
{
    Task<TEntity?> GetByIdAsync(Guid id, CancellationToken ctk = default);
    Task<IList<TEntity>> ListAllAsync();
    Task<List<TEntity?>> ListAsync(ISpecification<TEntity> spec, CancellationToken ctk = default);
    Task<TEntity?> FirstOrDefaultAsync(ISpecification<TEntity> spec, CancellationToken ctk = default);
    Task<TEntity> AddAsync(TEntity entity, CancellationToken ctk);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    Task<int> CountAsync(ISpecification<TEntity> spec);
}