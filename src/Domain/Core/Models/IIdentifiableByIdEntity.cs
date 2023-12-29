namespace MyApp.Domain.Core.Models;

public interface IIdentifiableByIdEntity
{
    public Guid Id { get; set; }
}