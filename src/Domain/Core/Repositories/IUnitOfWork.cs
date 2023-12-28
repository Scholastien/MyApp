using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Core.Models;

namespace MyApp.Domain.Core.Repositories;

public interface IUnitOfWork
{
    /// <summary>
    /// Saves all changes made in this context to the database.
    /// </summary>
    /// <param name="ctk"> A CancellationToken to observe while waiting for the task to complete </param>
    /// <returns> A task that represents the asynchronous save operation. The task result contains the number of state entries written to the database. </returns>
    /// <exception cref="DbUpdateException"> An error is encountered while saving to the database.
    /// </exception>
    /// <exception cref="DbUpdateConcurrencyException"> A concurrency violation is encountered while saving to the database. A concurrency violation occurs when an unexpected number of rows are affected during save. This is usually because the data in the database has been modified since it was loaded into memory.
    /// </exception>
    /// <exception cref="OperationCanceledException"> If the CancellationToken is canceled.
    /// </exception>
    Task<int> SaveChangesAsync(CancellationToken ctk = default);

    /// <summary>
    /// Discards the outstanding operations in the current transaction.
    /// </summary>
    /// <param name="ctk"> A CancellationToken to observe while waiting for the task to complete </param>
    /// <exception cref="OperationCanceledException"> If the CancellationToken is canceled. </exception>
    Task RollBackChangesAsync(CancellationToken ctk = default);

    /// <summary>
    /// Create an instance of Repository for a given type T.
    /// </summary>
    /// <typeparam name="T"> A generic type representing a BaseEntity. </typeparam>
    /// <returns> A Repository base on type T. </returns>
    /// <exception cref="NullReferenceException"> If the Repository is null.
    /// </exception>
    IBaseRepositoryAsync<T> Repository<T>() where T : BaseEntity;
}