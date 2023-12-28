﻿using MyApp.Domain.Core.Specifications;
using MyApp.Domain.Entities.Customers;
using MyApp.Domain.Enums;

namespace MyApp.Domain.Specifications.Customers;

public static class CustomerSpecifications<T> where T : Customer
{
    public static BaseSpecification<T> GetCustomerByEmail(string emailId)
    {
        return new BaseSpecification<T>(c => c.Email == emailId && c.IsDeleted == false);
    }

    public static BaseSpecification<T> GetAllActiveCustomersSpec()
    {
        return new BaseSpecification<T>(c => c.StatusEnum == CustomerStatusEnum.Active && c.IsDeleted == false);
    }
}