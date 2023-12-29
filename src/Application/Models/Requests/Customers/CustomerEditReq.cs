using System.ComponentModel.DataAnnotations;
using MyApp.Application.Models.DTOs.Customers;
using MyApp.Domain.Entities.Customers;

namespace MyApp.Application.Models.Requests.Customers;

public abstract class CustomerEditReq<TCustomerDto,TCustomer> : BaseEditRequest<TCustomerDto, TCustomer>
    where TCustomerDto : CustomerDto<TCustomer> 
    where TCustomer : Customer
{
    [Required]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Email { get; set; }

    protected CustomerEditReq()
    {
    }

    protected CustomerEditReq(TCustomerDto data)
    {
        Id = data.Id;
        Email = data.Email;
        
        // TODO : shipping address
    }

    public override void WriteTo(TCustomer customer)
    {
        customer.Email = Email;
        
        // TODO : shipping address
    }
}