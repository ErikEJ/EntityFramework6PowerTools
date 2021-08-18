# Preview of EF6 SQL Server provider based on Microsoft.Data.SqlClient


Latest build of this preview package is available from [NuGet](https://www.nuget.org/packages/ErikEJ.EntityFramework.SqlServer/)

## Configuration

In order to use the provider, you can register it in code using an attribute:

````csharp
    [DbConfigurationType(typeof(System.Data.Entity.SqlServer.MicrosoftSqlDbConfiguration))]
    public class SchoolContext : DbContext
    {
        public SchoolContext() : base()
        {
        }

        public DbSet<Student> Students { get; set; }
    }
````
If you have multiple classes inheriting from DbContext in your solution, make sure add the DbConfigurationType attribute to all of them.

Or you can use the SetConfiguration method before any data access calls:
````csharp
 DbConfiguration.SetConfiguration(new System.Data.Entity.SqlServer.MicrosoftSqlDbConfiguration());
````
Or you can add the following lines to your existing DbConfiguration class:
````csharp
SetProviderFactory(MicrosoftSqlProviderServices.ProviderInvariantName, Microsoft.Data.SqlClient.SqlClientFactory.Instance);
SetProviderServices(MicrosoftSqlProviderServices.ProviderInvariantName, MicrosoftSqlProviderServices.Instance);
````
You can also use XML/App.Config based configuration:

````xml
  <entityFramework>
    <providers>
      <provider invariantName="Microsoft.Data.SqlClient" type="System.Data.Entity.SqlServer.MicrosoftSqlProviderServices, ErikEJ.EntityFramework.SqlServer" />
    </providers>
  </entityFramework>
````

If you use an EDMX file, make sure to update the Provider name there:

````xml
<edmx:Edmx Version="3.0" xmlns:edmx="http://schemas.microsoft.com/ado/2009/11/edmx">
  <edmx:Runtime>
    <edmx:StorageModels>
      <Schema Namespace="ChinookModel.Store" Provider="Microsoft.Data.SqlClient" >
````

## Code changes

`using System.Data.SqlClient;` => `using Microsoft.Data.SqlClient;`

Please report any issues and questions in the dedicated issue [here](https://github.com/ErikEJ/EntityFramework6PowerTools/issues/82)
