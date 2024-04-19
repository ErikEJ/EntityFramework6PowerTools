# Entity Framework 6 Power Tools Community Edition

This is a fork of the "official" [EF 6 repository](https://github.com/aspnet/entityFramework6/), which hosts the Visual Studio 2017 and 2019 versions of EF Power Tools and also a modern EF 6 SQL Server runtime provider, that uses the modern Microsoft.Data.SqlClient ADO.NET provider.  

# What are the Power Tools?

Useful design-time utilities for EF 6, accessible through the Visual Studio Solution Explorer context menu. 

When right-clicking on a file containing a derived DbContext class, the following context menu functions are available: 
1. View Entity Data Model (Read-only)
2. View Entity Data Model XML 
3. View Entity Data Model DDL SQL 
4. Generate Views 

When right-clicking on an Entity Data Model .edmx  file, the following context menu function is available: 
- Generate Views.

When right-clicking a project, the following menu function is available:
- Customize Reverse Engineer Templates

If you are looking for Reverse Engineering tools, I recommend using the ["Code First from Database" feature](http://www.entityframeworktutorial.net/code-first/code-first-from-existing-database.aspx) that is included with the standard Visual Studio tooling for EF 6.

# EF6 SQL Server / Azure SQL Database provider based on Microsoft.Data.SqlClient

This is a replacement runtime provider for the built-in SQL Server provider.

**UPDATE** An [official Microsoft package](https://www.nuget.org/packages/Microsoft.EntityFramework.SqlServer/) based on this package has just been published.

See the [dedicated readme](https://github.com/ErikEJ/EntityFramework6PowerTools/blob/community/src/ErikEJ.EntityFramework.SqlServer/readme.md) for more information.

# Preview of EF6 SQL Server Compact provider for .NET 6

This is an update of the SQL Server Compact provider, that runs under .NET 6 on Windows.

See the [dedicated readme](https://github.com/ErikEJ/EntityFramework6PowerTools/blob/community/src/ErikEJ.EntityFramework.SqlServerCompact/readme.md) for more information.

# Downloads/builds

**Release**

The Power Tools will remain in "beta" status, and will not be ported to Visual Studio 2022 or later.

Download the latest released version from [Visual Studio MarketPlace](https://marketplace.visualstudio.com/items?itemName=ErikEJ.EntityFramework6PowerToolsCommunityEdition)

Or just install from Tools, Extensions and Updates in Visual Studio! ![](https://github.com/ErikEJ/SqlCeToolbox/blob/master/img/ext.png)

You can download the daily build from [VSIX Gallery](https://www.vsixgallery.com/extension/F0A7D01D-4834-44C3-99B2-5907A0701906).

Install the [VSIX Gallery Nightly builds extension](https://marketplace.visualstudio.com/items?itemName=MadsKristensen.VSIXGallery-nightlybuilds) to get the latest daily build automatically.

# How do I contribute

There are lots of ways to contribute, including testing out nighty builds, reporting bugs, and contributing code.

If you encounter a bug or have a feature request, please use the [Issue Tracker](https://github.com/ErikEJ/EntityFramework6PowerTools/issues/new).

# Release Notes

## Release 0.9.126 (September, 2021)

* Removed support for Visual Studio 2022

## Release 0.9.86 (August, 2021)

* Added support for Visual Studio 2022

## Release 0.9.75 (January, 2020)

* Added "Customize Reverse Engineering Templates" project menu item
* Improved logging when constructing DbContext
* Remove support for VS 2015

## Release 0.9.65 (January, 2019)

* About dialog added
* VSPackage made Async (to support newer VS versions)
* Support for Visual Studio 2019
* Support for multiple projects with DbContext using same name - thanks to [PhilPJL](https://github.com/PhilPJL)

## Release 0.9.35 (July 19, 2017)

* Fix error: "Unable to open configSource" with linked config files - thanks to [CZEMacLeod](https://github.com/CZEMacLeod) 
* Clean temp files

## Release 0.9.20 (July 11, 2017)

Initial release based on the current EF codebase

# Feature details

## View Entity Data Model (Read-only)

Even when developing with code first, you might want to graphically view your model. This View Entity Data Model option displays a read-only view of the Code First model in the EF Designer. Even though the designer will let you modify the model, you would not be able to save your changes.

## View Entity Data Model XML

This option allows you to view the EDMX XML representing the underlying Code First model. You probably will not be using this option on too many occasions. One case where you may need to use it is when debugging some Code First issues.

## View Entity Data Model DDL SQL

This option allows you to view the DDL SQL script that corresponds to the SSDL in the underlying EDM Model. You may want to use this option when you want to review the tables and columns that will get produced by your model.

## Generating Pre-compiled Views 

You can use Generate Views option to generate pre-compiled views that are used by the Entity Framework runtime to improve start-up performance. The generated views file is added to the project. You can read more about view compilation in the following article: Performance Considerations.
The Generate Views option is available when working with Code First and also when working with the EF Designer.
When working with Code First, Generate Views option is available when right-clicking on a file that contains a derived DbContext class.
When working with the EF Designer, Generate Views option is available when right-clicking on the EDMX file.
Note that, every time you change your model you need to re-generate the pre-compiled views by running the GenerateViews command again.

## Customize Reverse Engineer Templates

This feature lets you customize code generation via reverse engineer T4 templates added to your project.
