﻿using MyApp.Application.Interfaces.Models.Requests;
using MyApp.Application.Models.Dtos;
using MyApp.Domain.Core.Models;

namespace MyApp.Application.Models.Responses;

public class MultipleBaseResponse<TDto, TEntity> : IBaseResponse<IList<TDto>>
    where TDto : BaseDto<TEntity> 
    where TEntity : BaseEntity
{
    public IList<TDto> Data { get; set; }
}