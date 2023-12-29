using MyApp.Application.Interfaces.Models;
using MyApp.Application.Models.DTOs;
using MyApp.Domain.Core.Models;

namespace MyApp.Application.Models.Responses;

public class MultipleBaseResponse<TDto, TEntity> : IBaseResponse<IList<TDto>>
    where TDto : BaseDto<TEntity> 
    where TEntity : BaseEntity
{
    public IList<TDto> Data { get; set; }
}