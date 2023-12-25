namespace MyApp.Domain.Enums;

[Flags]
public enum RoleEnum : ushort
{
    None = 0,
    Admin = 1 << 0,
    Salesman = 1 << 1,
    CustomerService = 1 << 2
}