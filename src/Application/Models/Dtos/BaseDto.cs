using MyApp.Domain.Core.Models;

namespace MyApp.Application.Models.DTOs;

public abstract class BaseDto<T> where T : BaseEntity
{
    protected BaseDto(){}


    protected BaseDto(T customer)
    {
    }

    public virtual void WriteTo(T customer)
    {
    }
}