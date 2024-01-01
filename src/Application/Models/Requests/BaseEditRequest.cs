using MyApp.Application.Models.DTOs;
using MyApp.Domain.Core.Models;

namespace MyApp.Application.Models.Requests;

public abstract class BaseEditRequest<TDto, TEntity>
    where TDto : BaseDto<TEntity> 
    where TEntity : BaseEntity
{
    public string Controller { get; set; }
    protected BaseEditRequest()
    {
    }

    protected BaseEditRequest(TDto data)
    {
    }

    public virtual void WriteTo(TEntity customer)
    {
        
    }
}