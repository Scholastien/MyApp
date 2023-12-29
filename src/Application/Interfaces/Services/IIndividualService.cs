using MyApp.Application.Models.DTOs.Customers;
using MyApp.Application.Models.Requests.Customers.Individuals;
using MyApp.Application.Models.Responses.Customers.Individuals;

namespace MyApp.Application.Interfaces.Services;

public interface IIndividualService
{
    Task<IndividualRes> CreateIndividual(IndividualCreateReq createReq, CancellationToken ctk = default);
    Task UpdateIndividual(IndividualEditReq editReq, CancellationToken ctk = default);
    Task<MultipleIndividualsRes> GetAllActiveIndividuals(CancellationToken ctk = default);
    Task<IndividualDto> GetIndividualDtoById(Guid id, CancellationToken ctk = default);
    Task DeleteIndividualWithId(Guid id, CancellationToken ctk = default);
}