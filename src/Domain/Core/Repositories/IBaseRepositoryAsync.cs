using MyApp.Domain.Core.Models;
using MyApp.Domain.Core.Specifications;

namespace MyApp.Domain.Core.Repositories;

public interface IBaseRepositoryAsync<T> where T : BaseEntity
{
    Task<T?> GetByIdAsync(Guid id, CancellationToken ctk = default);
    Task<IList<T>> ListAllAsync();
    Task<IList<T?>> ListAsync(ISpecification<T> spec, CancellationToken ctk = default);
    Task<T?> FirstOrDefaultAsync(ISpecification<T> spec);
    Task<T> AddAsync(T entity, CancellationToken ctk);
    void Update(T entity);
    void Delete(T entity);
    Task<int> CountAsync(ISpecification<T> spec);
}