using MyApp.Application.Models.DTOs.Customers;
using MyApp.Domain.Entities.Customers;

namespace MyApp.Application.Models.Responses.Customers.Individuals;

public class MultipleIndividualsRes : MultipleCustomersRes<IndividualDto, Individual>
{
}