using MyApp.Domain.Core.Specifications;
using MyApp.Domain.Entities;
using MyApp.Domain.Enums;

namespace MyApp.Domain.Specifications;

public static class CustomerSpecifications
{
    public static BaseSpecification<Customer> GetUserByEmail(string emailId)
    {
        return new BaseSpecification<Customer>(c => c.EmailId == emailId && c.IsDeleted == false);
    }

    public static BaseSpecification<Customer> GetAllActiveUsersSpec()
    {
        return new BaseSpecification<Customer>(c => c.Status == CustomerStatus.Active && c.IsDeleted == false);
    }
}