namespace MyApp.Application.Interfaces.Models.Requests;

public interface IBaseResponse<TDto>
{
    TDto Data { get; set; }
}