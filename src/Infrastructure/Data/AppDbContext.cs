using Microsoft.EntityFrameworkCore;

namespace MyApp.Infrastructure.Data
{
    public class MyAppDbContext : DbContext
    {
        public MyAppDbContext(DbContextOptions<MyAppDbContext> options) : base(options)
        { }

    }
}