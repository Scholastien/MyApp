﻿using MyApp.Domain.Core.Models;

namespace MyApp.Application.Models.Dtos;

public abstract class BaseDto<T> where T : BaseEntity
{
    protected BaseDto(){}


    protected BaseDto(T entity)
    {
    }

    public virtual void WriteTo(T entity)
    {
    }
}