﻿using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Core.Models;
using MyApp.Domain.Core.Repositories;
using MyApp.Domain.Core.Specifications;
using MyApp.Infrastructure.Data;

namespace MyApp.Infrastructure.Repositories;

public class BaseRepositoryAsync<T> : IBaseRepositoryAsync<T> where T : BaseEntity
{
    private readonly AppDbContext _dbContext;

    public BaseRepositoryAsync(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public virtual async Task<T?> GetByIdAsync(Guid id, CancellationToken ctk)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public async Task<IList<T>> ListAllAsync()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public async Task<IList<T?>> ListAsync(ISpecification<T> spec, CancellationToken ctk)
    {
        return await ApplySpecification(spec).ToListAsync();
    }

    public async Task<T?> FirstOrDefaultAsync(ISpecification<T> spec)
    {
        return await ApplySpecification(spec).FirstOrDefaultAsync();
    }

    public async Task<int> CountAsync(ISpecification<T> spec)
    {
        return await ApplySpecification(spec).CountAsync();
    }

    public async Task<T> AddAsync(T entity, CancellationToken ctk)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        return entity;
    }

    public void Update(T entity)
    {
        _dbContext.Set<T>().Update(entity);
    }

    public void Delete(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
    }

    private IQueryable<T?> ApplySpecification(ISpecification<T> spec)
    {
        return SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>().AsQueryable(), spec);
    }
}