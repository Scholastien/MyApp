using MyApp.Domain.Entities.Customers;
using MyApp.Domain.Enums;
using MyApp.Domain.Specifications.Customers;
using MyApp.Domain.Test.Helpers;

namespace MyApp.Domain.Test.Specifications;

public class CustomerSpecificationsTest
{
    private readonly List<Customer> _customers;
    private readonly Guid _guid1 = Guid.NewGuid();
    public CustomerSpecificationsTest()
    {
        _customers = new List<Customer>{
            new Individual
            {
                Id = _guid1,
                FirstName = "Pierre",
                LastName = "Paul",
                Email = "pierre.paul@test.com",
                PhoneNumber = "5665566556",
                StatusEnum = CustomerStatusEnum.Active
            },
            new Individual
            {
                Id = Guid.NewGuid(),
                FirstName = "Jacques",
                LastName = "Goldman",
                Email = "Jacques.Goldman@test.com",
                PhoneNumber = "5665566556",
                StatusEnum = CustomerStatusEnum.Active
            },
            new Individual
            {
                Id = Guid.NewGuid(),
                FirstName = "Jean",
                LastName = "Marie",
                Email = "Jean.Marie@test.com",
                PhoneNumber = "5665566556",
                StatusEnum = CustomerStatusEnum.Inactive
            },
        };
    }

    [Fact]
    public void Given_ValidData_When_GetCustomerByIdSpec_Then_ReturnValidData()
    {
        // Arrange
        var spec = CustomerSpecifications<Customer>.GetCustomerByIdSpec(_guid1);

        // Act
        var count = SpecificationEvaluatorTestHelper<Customer>.GetQuery(_customers.AsQueryable(), spec).Count();

        // Assert
        Assert.Equal(1, count);
    }

    [Fact]
    public void Given_ValidData_When_GetAllActiveUsersSpec_Then_ReturnValidData()
    {
        // Arrange
        var spec = CustomerSpecifications<Customer>.GetAllActiveCustomersSpec();

        // Act
        var count = SpecificationEvaluatorTestHelper<Customer>.GetQuery(_customers.AsQueryable(), spec).Count();

        // Assert
        Assert.Equal(2, count);
    }
}