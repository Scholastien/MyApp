﻿using MyApp.Domain.Core.Specifications;
using MyApp.Domain.Entities;
using MyApp.Domain.Enums;

namespace MyApp.Domain.Specifications;

public static class CustomerSpecifications
{
    public static BaseSpecification<Customer> GetUserByEmail(string emailId)
    {
        return new BaseSpecification<Customer>(x => x.EmailId == emailId && x.IsDeleted == false);
    }

    public static BaseSpecification<Customer> GetAllActiveUsersSpec()
    {
        return new BaseSpecification<Customer>(x => x.Status == CustomerStatus.Active && x.IsDeleted == false);
    }
}