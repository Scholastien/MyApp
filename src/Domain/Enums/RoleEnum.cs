namespace MyApp.Domain.Enums;

// TODO: utiliser ASP userRoles ici
[Flags]
public enum RoleEnum : ushort
{
    None = 0,
    Admin = 1 << 0,
    Salesman = 1 << 1,
    CustomerService = 1 << 2
}

public static class RoleEnumExtension
{
    public static bool IsAdmin(this RoleEnum role) 
        => role == RoleEnum.Admin;
    public static bool IsSalesman(this RoleEnum role) 
        => role == RoleEnum.Salesman;
    public static bool IsCustomerService(this RoleEnum role) 
        => role == RoleEnum.CustomerService;
    public static bool IsSalesmanAndCustomerService(this RoleEnum role) 
        => role == (RoleEnum.Salesman |
                    RoleEnum.CustomerService);
}