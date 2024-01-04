using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;

var builder = WebApplication.CreateBuilder(args);


var appSettings = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .Build();

MyApp.Application.DependencyInjections.ConfigureServices(builder.Services);

MyApp.Infrastructure.DependencyInjections.ConfigureServices(builder.Services, appSettings);

var services = builder.Services;

services.AddEndpointsApiExplorer();

services.AddSwaggerGen();

services.AddControllersWithViews()
    .AddSessionStateTempDataProvider();

services.AddHttpContextAccessor();

services.AddDistributedMemoryCache();

services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// builder.Services.AddDataProtection()
//     .SetApplicationName("WebApi")
//     .PersistKeysToFileSystem(new DirectoryInfo("/var/dpkeys/"));

services.AddDataProtection()
    .SetApplicationName("WebApi")
    .PersistKeysToFileSystem(new DirectoryInfo("/var/temp-key/"))
    .UseCryptographicAlgorithms(new AuthenticatedEncryptorConfiguration
    {
        EncryptionAlgorithm = EncryptionAlgorithm.AES_256_CBC,
        ValidationAlgorithm = ValidationAlgorithm.HMACSHA256
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// app.UseHttpsRedirection(); // TODO: configure HTTPS endpoint + specify server certificate

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseSession();

#pragma warning disable ASP0014
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapRazorPages();
});
#pragma warning restore ASP0014

using (var scope = app.Services.CreateScope())
{
    MyApp.Infrastructure.DependencyInjections.MigrateDatabase(scope.ServiceProvider);
}

app.Run();