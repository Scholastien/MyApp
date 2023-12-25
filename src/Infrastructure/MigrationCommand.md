# Ajouter migration :
Pour ajouter une migration remplacer le ~~MigrationName~~ => un nom de migration cohérent :
````properties
dotnet ef migrations add MigrationName --startup-project ../MyApp.WebApi/MyApp.WebApi.csproj --output-dir Data/Migrations  
````