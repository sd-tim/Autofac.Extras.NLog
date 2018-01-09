# AutoFac.Extras.NLog

## Getting Started
The solution contains projects targeting both .NET Core 2.0 and .NET Framework 4.5. In order to successfully build, both `dotnet restore` _and_ `nuget restore` need to be run to restore the nuget packages for all projects:

 1. `dotnet restore ./Autofac.Extras.NLog.sln`
 1. `nuget restore ./Autofac.Extras.NLog.sln`
 1. `dotnet build ./Autofac.Extras.NLog.sln`
 1. `dotnet test .`