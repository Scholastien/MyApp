namespace MyApp.Application.Interfaces.Models.Dtos;

public interface ICustomerDto
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public int Status { get; set; }
    public string StatusText { get; set; }
}