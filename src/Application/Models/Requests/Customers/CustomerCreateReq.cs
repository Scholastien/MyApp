using System.ComponentModel.DataAnnotations;
using MyApp.Application.Interfaces.Models.Requests.Customers;
using MyApp.Application.Interfaces.Models.Requests.CustomersDetails;

namespace MyApp.Application.Models.Requests.Customers;

public abstract class CustomerCreateReq : ICustomerReq, IBothCustomerDetailsReq
{
    #region ICustomerReq

    [MaxLength(50)]
    [Required(ErrorMessage = "Email is required")]
    public string Email { get; set; }

    [MaxLength(15)]
    [Required(ErrorMessage = "PhoneNumber is required")]
    public string PhoneNumber { get; set; }

    #endregion

    #region ICustomerDetailsReq

    [MaxLength(100)]
    [Required(ErrorMessage = "Billing Street is required")]
    public string BStreet { get; set; }

    [MaxLength(100)]
    [Required(ErrorMessage = "Billing City is required")]
    public string BCity { get; set; }

    [MaxLength(100)]
    [Required(ErrorMessage = "Billing PostalCode is required")]
    public string BPostalCode { get; set; }

    [MaxLength(100)]
    [Required(ErrorMessage = "Billing State is required")]
    public string BState { get; set; }

    [MaxLength(100)]
    [Required(ErrorMessage = "Billing Country is required")]
    public string BCountry { get; set; }

    [MaxLength(100)]
    [Required(ErrorMessage = "Shipping City is required")]
    public string SCity { get; set; }


    [MaxLength(100)]
    [Required(ErrorMessage = "Shipping Street is required")]
    public string SStreet { get; set; }

    [MaxLength(100)]
    [Required(ErrorMessage = "Shipping Postal Code is required")]
    public string SPostalCode { get; set; }

    [MaxLength(100)]
    [Required(ErrorMessage = "Shipping State is required")]
    public string SState { get; set; }

    [MaxLength(100)]
    [Required(ErrorMessage = "Shipping Country is required")]
    public string SCountry { get; set; }

    #endregion
}