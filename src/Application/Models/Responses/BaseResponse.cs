using MyApp.Application.Interfaces.Models.Requests;
using MyApp.Application.Models.Dtos;
using MyApp.Domain.Core.Models;

namespace MyApp.Application.Models.Responses;

public class BaseResponse<TDto, TEntity> : IBaseResponse<TDto>
    where TDto : BaseDto<TEntity> 
    where TEntity : BaseEntity
{
    public TDto Data { get; set; }
}