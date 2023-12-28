using MyApp.Application.Models.DTOs.Customers;
using MyApp.Application.Models.Requests.Customers.Individuals;
using MyApp.Application.Models.Responses.Customers;

namespace MyApp.Application.Interfaces;

public interface IIndividualService<T> where T : CustomerDto
{
    Task<CreateCustomerRes<T>> CreateIndividual(IndividualCreateReq createReq, CancellationToken ctk = default);
    Task UpdateIndividual(IndividualEditReq editReq, CancellationToken ctk = default);
    Task<GetAllActiveCustomersRes<T>> GetAllActiveIndividuals(CancellationToken ctk = default);
    Task<IndividualDto> GetIndividualDtoById(Guid id, CancellationToken ctk = default);
    Task DeleteIndividualWithId(Guid id, CancellationToken ctk = default);
}