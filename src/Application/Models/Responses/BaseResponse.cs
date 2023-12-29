using MyApp.Application.Interfaces.Models;
using MyApp.Application.Models.DTOs;
using MyApp.Domain.Core.Models;

namespace MyApp.Application.Models.Responses;

public class BaseResponse<TDto, TEntity> : IBaseResponse<TDto>
    where TDto : BaseDto<TEntity> 
    where TEntity : BaseEntity
{
    public TDto Data { get; set; }
}