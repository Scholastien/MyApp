using MyApp.Domain.Core.Specifications;
using MyApp.Domain.Entities.Customers;
using MyApp.Domain.Enums;

namespace MyApp.Domain.Specifications.Customers;

public static class IndividualSpecifications
{
    public static BaseSpecification<Individual> GetCustomerByEmail(string emailId)
    {
        return new BaseSpecification<Individual>(c => c.Email == emailId && c.IsDeleted == false);
    }

    public static BaseSpecification<Individual> GetAllActiveCustomersSpec()
    {
        return new BaseSpecification<Individual>(c => c.StatusEnum == CustomerStatusEnum.Active && c.IsDeleted == false);
    }
}