# Entity Framework 6 SQL Server provider based on Microsoft.Data.SqlClient

This Entity Framework 6 provider is a replacement provider for the built-in SQL Server provider. 

This provider depends on the modern Microsoft.Data.SqlClient ADO.NET provider, see my [blog post here](https://erikej.github.io/ef6/sqlserver/2021/08/08/ef6-microsoft-data-sqlclient.html) for why that can be desirable.

The latest build of this package is available from [NuGet](https://www.nuget.org/packages/ErikEJ.EntityFramework.SqlServer/)

## Configuration

There are various ways to configure Entity Framework to use this provider.

You can register the provider in code using an attribute:

````csharp
    [DbConfigurationType(typeof(MicrosoftSqlDbConfiguration))]
    public class SchoolContext : DbContext
    {
        public SchoolContext() : base()
        {
        }

        public DbSet<Student> Students { get; set; }
    }
````
If you have multiple classes inheriting from DbContext in your solution, add the DbConfigurationType attribute to all of them.

Or you can use the SetConfiguration method before any data access calls:
````csharp
 DbConfiguration.SetConfiguration(new MicrosoftSqlDbConfiguration());
````
Or you can add the following lines to your existing DbConfiguration class:
````csharp
SetProviderFactory(MicrosoftSqlProviderServices.ProviderInvariantName, Microsoft.Data.SqlClient.SqlClientFactory.Instance);
SetProviderServices(MicrosoftSqlProviderServices.ProviderInvariantName, MicrosoftSqlProviderServices.Instance);
// Optional
SetExecutionStrategy(MicrosoftSqlProviderServices.ProviderInvariantName, () => new MicrosoftSqlAzureExecutionStrategy());
````
You can also use XML/App.Config based configuration:

````xml
  <entityFramework>
    <providers>
      <provider invariantName="Microsoft.Data.SqlClient" type="System.Data.Entity.SqlServer.MicrosoftSqlProviderServices, ErikEJ.EntityFramework.SqlServer" />
    </providers>
  </entityFramework>
````

If you use an EDMX file, update the Provider name there:

````xml
<edmx:Edmx Version="3.0" xmlns:edmx="http://schemas.microsoft.com/ado/2009/11/edmx">
  <edmx:Runtime>
    <edmx:StorageModels>
      <Schema Namespace="ChinookModel.Store" Provider="Microsoft.Data.SqlClient" >
````

## Code changes

In order to use the provider in an existing solution, a few code changes are required (as needed).

`using System.Data.SqlClient;` => `using Microsoft.Data.SqlClient;`

`SqlAzureExecutionStrategy` => `MicrosoftSqlAzureExecutionStrategy`

## Feedback

Please report any issues, questions and suggestions [here](https://github.com/ErikEJ/EntityFramework6PowerTools/issues)
