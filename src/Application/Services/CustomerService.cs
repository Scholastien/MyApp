using MyApp.Application.Core.Services;
using MyApp.Application.Interfaces;
using MyApp.Application.Models.DTOs;
using MyApp.Application.Models.Requests;
using MyApp.Application.Models.Responses;
using MyApp.Domain.Core.Repositories;
using MyApp.Domain.Entities;
using MyApp.Domain.Specifications;

namespace MyApp.Application.Services;

public class CustomerService : ICustomerService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILoggerService _loggerService;

    public CustomerService(IUnitOfWork unitOfWork, ILoggerService loggerService)
    {
        _unitOfWork = unitOfWork;
        _loggerService = loggerService;
    }

    public async Task<CreateCustomerRes> CreateUser(CustomerCreateReq req)
    {
        var customer = await _unitOfWork.Repository<Customer>().AddAsync(new Customer
        {
            FirstName = req.FirstName,
            LastName = req.LastName,
            EmailId = req.EmailId,
            Address = req.Address,
        });

        await _unitOfWork.SaveChangesAsync();

        _loggerService.LogInfo("New customer created");

        return new CreateCustomerRes() { Data = new CustomerDTO(customer) };
    }

    public async Task<GetAllActiveCustomersRes> GetAllActiveUsers()
    {
        var activeUsersSpec = CustomerSpecifications.GetAllActiveUsersSpec();

        var users = await _unitOfWork.Repository<Customer>().ListAsync(activeUsersSpec);

        return new GetAllActiveCustomersRes
        {
            Data = users.Select(x => new CustomerDTO(x)).ToList()
        };
    }
}