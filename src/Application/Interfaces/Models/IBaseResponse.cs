namespace MyApp.Application.Interfaces.Models;

public interface IBaseResponse<TDto>
{
    TDto Data { get; set; }
}