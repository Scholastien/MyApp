using Microsoft.AspNetCore.DataProtection;

var builder = WebApplication.CreateBuilder(args);


var appSettings = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .Build();

MyApp.Application.DependencyInjections.ConfigureServices(builder.Services);

MyApp.Infrastructure.DependencyInjections.ConfigureServices(builder.Services, appSettings);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddControllersWithViews();

builder.Services.AddDataProtection()
    .SetApplicationName("WebApi")
    .PersistKeysToFileSystem(new DirectoryInfo("/var/dpkeys/"));

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

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapRazorPages();
});

using (var scope = app.Services.CreateScope())
{
    MyApp.Infrastructure.DependencyInjections.MigrateDatabase(scope.ServiceProvider);
}

app.Run();
