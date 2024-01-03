using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Entities.Products;
using MyApp.Infrastructure.Data;
using MyApp.Infrastructure.Repositories;

namespace MyApp.Infrastructure.Test.Repositories;

public class BaseRepositoryAsyncTest
{
    private readonly AppDbContext _appDbContext;
    private readonly UnitOfWork _unitOfWork;

    public BaseRepositoryAsyncTest()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(databaseName: "WebAppDb").Options;
        _appDbContext = new AppDbContext(options);
        _unitOfWork = new UnitOfWork(_appDbContext);
    }

    [Fact]
    public async void Given_ValidData_When_AddAsync_Then_SuccessfullyInsertData()
    {
        // Arrange
        var product = new Product
        {
            CreatedBy = Guid.NewGuid(),
            CreatedOn = DateTimeOffset.UtcNow,
            Name = "Test Product",
            Price = 100f
        };

        // Act
        var result = await _unitOfWork.Repository<Product>().AddAsync(product);
        await _unitOfWork.SaveChangesAsync();

        // Assert
        if (_appDbContext.Products != null)
        {
            Assert.Equal(result, await _appDbContext.Products.FindAsync(result.Id));
        }
    }
}