namespace MyApp.Domain.Core.Models.Interface;

public interface ISoftDeleteEntity
{
    public bool IsDeleted { get; set; }
}