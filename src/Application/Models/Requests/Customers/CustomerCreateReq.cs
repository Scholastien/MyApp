using System.ComponentModel.DataAnnotations;
using ExpressiveAnnotations.Attributes;

namespace MyApp.Application.Models.Requests.Customers;

public abstract class CustomerCreateReq
{
    public bool DifferentBillingAndShipping { get; set; } = false;

    [Required] [MaxLength(50)] public string Email { get; set; }
    
    [Required] [MaxLength(50)] public string PhoneNumber { get; set; }

    // [Required] [MaxLength(100)] public string BStreet { get; set; }
    // [Required] [MaxLength(100)] public string BCity { get; set; }
    // [Required] [MaxLength(100)] public string BPostalCode { get; set; }
    // [Required] [MaxLength(100)] public string BState { get; set; }
    // [Required] [MaxLength(100)] public string BCountry { get; set; }
    //
    // [RequiredIf("DifferentBillingAndShipping == true")]
    // [MaxLength(100)]
    // public string SCity { get; set; }
    //
    //
    // [RequiredIf("DifferentBillingAndShipping == true")]
    // [MaxLength(100)]
    // public string SStreet { get; set; }
    //
    // [RequiredIf("DifferentBillingAndShipping == true")]
    // [MaxLength(100)]
    // public string SPostalCode { get; set; }
    //
    // [RequiredIf("DifferentBillingAndShipping == true")]
    // [MaxLength(100)]
    // public string SState { get; set; }
    //
    // [RequiredIf("DifferentBillingAndShipping == true")]
    // [MaxLength(100)]
    // public string SCountry { get; set; }
}