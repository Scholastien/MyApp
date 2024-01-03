using MyApp.Application.Interfaces.Models.Requests;
using MyApp.Application.Models.Dtos.Customers;
using MyApp.Application.Models.Dtos.Customers.Individuals;
using MyApp.Application.Models.Requests.Customers.Individuals;
using MyApp.Application.Models.Responses.Customers.Individuals;

namespace MyApp.Application.Interfaces.Services;

public interface IIndividualService
{
    Task<IBaseResponse<IndividualWithDetailsDto>> CreateIndividual(IndividualCreateReq createReq, CancellationToken ctk = default);
    Task UpdateIndividual(IndividualEditReq editReq, CancellationToken ctk = default);
    Task<MultipleIndividualsRes> GetAllActiveIndividuals(CancellationToken ctk = default);
    Task<IndividualWithDetailsDto> GetIndividualDtoById(Guid id, CancellationToken ctk = default);
    Task DeleteIndividualWithId(Guid id, CancellationToken ctk = default);
    Task<IndividualWithDetailsDto> GetIndividualWithDetailsDtoById(Guid id, CancellationToken ctk = default);
}