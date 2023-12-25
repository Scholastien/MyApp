using MyApp.Application.Models.Requests;
using MyApp.Application.Models.Responses;

namespace MyApp.Application.Interfaces;

public interface ICustomerService
{
    Task<CreateCustomerRes> CreateUser(CustomerCreateReq req);

    Task<GetAllActiveCustomersRes> GetAllActiveUsers();
}