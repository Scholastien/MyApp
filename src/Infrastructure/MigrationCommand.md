# Ajouter migration :
Pour ajouter une migration remplacer le ~~MigrationName~~ => un nom de migration cohérent :

```properties
dotnet ef migrations add MigrationName --project src\Infrastructure\Infrastructure.csproj --startup-project src\WebApi\WebApi.csproj --context MyApp.Infrastructure.Data.AppDbContext --output-dir Migrations
```