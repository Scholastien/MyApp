using MyApp.Application.Core.Services;
using MyApp.Domain.Core.Repositories;

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
}