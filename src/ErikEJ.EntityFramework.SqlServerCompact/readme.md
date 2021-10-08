# Entity Framework 6 SQL Server Compact provider for .NET 5 (and later)

This Entity Framework 6 provider enables you to use the SQL Server Compact embedded database. The package includes everything required to start creating and using a SQL Compact database with Entity Framework 6. 

The latest preview build of this package is available from [this AppVeyor NuGet feed](https://ci.appveyor.com/nuget/entityframework6-erikej)

## Configuration

There are various ways to configure Entity Framework to use this provider.

You can register the provider in code using an attribute:

````csharp
    [DbConfigurationType(typeof(SqlCeDbConfiguration))]
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
 DbConfiguration.SetConfiguration(new SqlCeDbConfiguration());
````
Or you can add the following lines to your existing DbConfiguration class:
````csharp
SetProviderFactory(SqlCeProviderServices.ProviderInvariantName, SqlServerCe.SqlCeProviderFactory.Instance);
SetProviderServices(SqlCeProviderServices.ProviderInvariantName, SqlCeProviderServices.Instance);
````
You can also use XML/App.Config based configuration:

````xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
	<configSections>
		<section name="entityFramework" type="System.Data.Entity.Internal.ConfigFile.EntityFrameworkSection, EntityFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" requirePermission="false" />
	</configSections>
	<entityFramework>
		<providers>		
			<provider invariantName="System.Data.SqlServerCe.4.0" type="System.Data.Entity.SqlServer.SqlCeProviderServices, ErikEJ.EntityFramework.SqlServerCompact" />
		</providers>
	</entityFramework>
</configuration>
````
If you use App.Config with a .NET Core / .NET 5 or later app, you must register the DbProviderFactory in code once:

````csharp
DbProviderFactories.RegisterFactory(SqlCeProviderServices.ProviderInvariantName, SqlServerCe.SqlCeProviderFactory.Instance);
````

## Feedback

Please report any issues, questions and suggestions [here](https://github.com/ErikEJ/EntityFramework6PowerTools/issues)
