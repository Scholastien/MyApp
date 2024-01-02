using MyApp.Application.Models.Dtos.Customers;
using MyApp.Domain.Entities.Customers;

namespace MyApp.Application.Models.Responses.Customers.Individuals;

public class MultipleIndividualsRes : MultipleCustomersRes<IndividualDto, Individual>
{
}