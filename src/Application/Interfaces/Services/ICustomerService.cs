using MyApp.Domain.Enums;

namespace MyApp.Application.Interfaces.Services;

public interface ICustomerService
{
    Task<CustomerTypeEnum> GetCustomerTypeWithId(Guid id);
}