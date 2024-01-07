namespace MyApp.Domain.Core.Models.Interface;

public interface IIdentifiableByIdEntity
{
    public Guid Id { get; set; }
}