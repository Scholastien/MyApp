namespace MyApp.Application.Interfaces.Models.Requests.CustomersDetails;

public interface IBothCustomerDetailsReq
{
    public string BStreet { get; set; }
    public string BCity { get; set; }
    public string BPostalCode { get; set; }
    public string BState { get; set; }
    public string BCountry { get; set; }
    public string SStreet { get; set; }
    public string SCity { get; set; }
    public string SPostalCode { get; set; }
    public string SState { get; set; }
    public string SCountry { get; set; }
}