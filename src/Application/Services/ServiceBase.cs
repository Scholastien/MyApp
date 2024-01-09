using MyApp.Application.Core.Services;
using MyApp.Domain.Core.Models;
using MyApp.Domain.Core.Repositories;
using MyApp.Domain.Core.Specifications;

namespace MyApp.Application.Services;

public abstract class ServiceBase
{
    protected readonly IUnitOfWork UnitOfWork;
    protected readonly ILoggerService LoggerService;
    
    protected ServiceBase(IUnitOfWork unitOfWork, ILoggerService loggerService)
    {
        UnitOfWork = unitOfWork;
        LoggerService = loggerService;
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"> Guid used as Primary Key on BaseEntity </param>
    /// <param name="ctk"> CancellationToken </param>
    /// <typeparam name="TBaseEntity"> BaseEntity </typeparam>
    /// <returns></returns>
    /// <exception cref="NullReferenceException"> Couldn't find Entity with ids </exception>
    protected async Task<TBaseEntity> GetEntityByIdAsync<TBaseEntity>(Guid id, CancellationToken ctk = default) where TBaseEntity : BaseEntity
    {
        var line = await UnitOfWork.Repository<TBaseEntity>().GetByIdAsync(id, ctk);

        if (line != null) return line;
        
        LoggerService.LogError($"Couldn't find {nameof(TBaseEntity)} with ID {id}");
        throw new NullReferenceException();
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="ids"> Array of Guid used as Primary Keys on BaseEntity </param>
    /// <param name="ctk"> CancellationToken </param>
    /// <typeparam name="TBaseEntity"> BaseEntity </typeparam>
    /// <returns></returns>
    /// <exception cref="NullReferenceException"> Couldn't find Entity with ids </exception>
    protected async Task<TBaseEntity> GetEntityByIdAsync<TBaseEntity>(object[] ids, CancellationToken ctk = default) where TBaseEntity : BaseEntity
    {
        var entity = await UnitOfWork.Repository<TBaseEntity>().GetByIdAsync(ids, ctk);

        if (entity != null) return entity;

        var errMsg = $"Couldn't find {nameof(TBaseEntity)} with IDs {ids}";
        throw new NullReferenceException(errMsg);
    }

    protected async Task UpdateAsync<TBaseEntity>(TBaseEntity entity, CancellationToken ctk = default) where TBaseEntity : BaseEntity
    {
        UnitOfWork.Repository<TBaseEntity>().Update(entity);
        await UnitOfWork.SaveChangesAsync(ctk);
    }

    protected async Task<TBaseEntity> FirstOrDefaultAsync<TBaseEntity>(BaseSpecification<TBaseEntity> spec, CancellationToken ctk = default)
        where TBaseEntity : BaseEntity
    {
        var entity = await UnitOfWork.Repository<TBaseEntity>().FirstOrDefaultAsync(spec, ctk);
        
        if (entity != null) return entity;

        var errMsg = $"Couldn't find {nameof(TBaseEntity)} with specs {spec.Criteria}";
        throw new NullReferenceException(errMsg);
    }
}