using MyApp.Application.Core.Services;
using MyApp.Application.Interfaces;
using MyApp.Application.Models.DTOs;
using MyApp.Application.Models.Requests;
using MyApp.Application.Models.Responses;
using MyApp.Domain.Core.Repositories;
using MyApp.Domain.Entities;
using MyApp.Domain.Enums;
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

    public async Task<CreateCustomerRes> CreateCustomer(CustomerCreateReq req, CancellationToken ctk = default)
    {
        var customer = await _unitOfWork.Repository<Customer>().AddAsync(new Customer
        {
            FirstName = req.FirstName,
            LastName = req.LastName,
            EmailId = req.EmailId,
            Address = req.Address,
            Status = CustomerStatus.Active,
            CreatedBy = Guid.NewGuid(),
            CreatedOn = DateTimeOffset.Now,
            IsDeleted = false
        }, ctk);

        await _unitOfWork.SaveChangesAsync(ctk);

        _loggerService.LogInfo("New customer created");

        return new CreateCustomerRes() { Data = new CustomerDTO(customer) };
    }

    public async Task UpdateCustomer(CustomerEditReq req, CancellationToken ctk = default)
    {
        try
        {
            var customer = await _unitOfWork.Repository<Customer>().GetByIdAsync(req.Id, ctk);
            req.WriteTo(customer);
            _unitOfWork.Repository<Customer>().Update(customer);
            await _unitOfWork.SaveChangesAsync(ctk);
        }
        catch (Exception e)
        {
            _loggerService.LogError(e.Message);
            throw;
        }
    }

    public async Task<GetAllActiveCustomersRes> GetAllActiveCustomers(CancellationToken ctk = default)
    {
        var activeUsersSpec = CustomerSpecifications.GetAllActiveUsersSpec();

        var customers = await _unitOfWork.Repository<Customer>().ListAsync(activeUsersSpec, ctk);

        return new GetAllActiveCustomersRes
        {
            Data = customers.Select(x => new CustomerDTO(x)).ToList()
        };
    }

    public async Task<CustomerDTO> GetCustomerDtoById(Guid id, CancellationToken ctk = default)
    {
        try
        {
            var customer = await _unitOfWork.Repository<Customer>().GetByIdAsync(id, ctk);

            return new CustomerDTO(customer);
        }
        catch (Exception e)
        {
            _loggerService.LogError(e.Message);
            throw;
        }
    }

    public async Task DeleteCustomerWithId(Guid id, CancellationToken ctk = default)
    {
        try
        {
            var user = await _unitOfWork.Repository<Customer>().GetByIdAsync(id, ctk);
            _unitOfWork.Repository<Customer>().Delete(user);
            await _unitOfWork.SaveChangesAsync(ctk);
        }
        catch (Exception e)
        {
            _loggerService.LogError(e.Message);
            throw;
        }
    }
}