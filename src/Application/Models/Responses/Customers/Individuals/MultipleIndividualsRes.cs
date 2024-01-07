using MyApp.Application.Models.Dtos.Customers.Individuals;
using MyApp.Domain.Entities.Customers;

namespace MyApp.Application.Models.Responses.Customers.Individuals;

public class MultipleIndividualsRes : MultipleCustomersRes<IndividualDto, Individual>
{
}