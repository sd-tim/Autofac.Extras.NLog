# Autofac.Extras.NLog
An Autofac module to integrate NLog into the component resolution process, providing constructor and property injection.

## Getting Started
The solution contains projects targetin `.NET Core 2.0` and `.NET Framework 4.5`. In order to successfully build the solution, it is necessary to first run *both* `nuget restore` and `dotnet restore`:

 1. `dotnet restore ./Autofac.Extras.NLog.sln`
 1. `nuget restore ./Autofac.Extras.NLog.sln`
 1. `dotnet build ./Autofac.Extras.NLog.sln`
 1. `dotnet test ./Autofac.Extras.NLog.sln`