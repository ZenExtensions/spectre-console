# Zen Spectre Console Extensions
[![Actions Status](https://github.com/ZenExtensions/spectre-console/workflows/.NET%20Core%20Build/badge.svg?branch=main)](https://github.com/ZenExtensions/spectre-console/actions) [![Actions Status](https://github.com/ZenExtensions/spectre-console/workflows/.NET%20Core%20Publish/badge.svg)](https://github.com/ZenExtensions/spectre-console/actions) [![Current Version](https://img.shields.io/badge/Version-1.5.0-brightgreen?logo=nuget&labelColor=30363D)](./CHANGELOG.md#150---2022-01-22)

# Overview

## Installing
You can add the package to your project using dotnet core CLI
```bash
dotnet add package ZenExtensions.Spectre.Console
```
or by package manager console in Visual Studio
```bash
Install-Package ZenExtensions.Spectre.Console
```

## Usage
Use the following steps to configure Zen Spectre Console Extensions. Please refer to [Changelog](./CHANGELOG.md) for changes between versions.

### 1. Create Startup Class
```csharp
using Zen.Host;

public class Startup : BaseStartup
{
    public override void ConfigureServices(IServiceCollection services, IConfigurationRoot configuration)
    {
    }
}
```

### 2. Create Spectre Configurator
```csharp
public class SpectreConfiguration : ISpectreConfiguration
{
    public override void ConfigureCommandApp(in IConfigurator configurator)
    {
    }
}
```

### 2. Configure Program file
```csharp
using ZenExtensions.Spectre.Console;
using System.Threading.Tasks;

class Program
{
    public static async Task<int> Main(string[] args) => 
        await SpectreConsoleHost
            .WithStartup<Startup>()
            .UseConfigurator<SpectreConfiguration>()
            .RunAsync(args);
        
}
```
You can also have a default command using generic SpectreConsoleHost.
```csharp
using ZenExtensions.Spectre.Console;
using System.Threading.Tasks;

class Program
{
    public static async Task<int> Main(string[] args) => 
        await SpectreConsoleHost<MainCommand>
            .WithStartup<Startup>()
            .UseConfigurator<SpectreConfiguration>()
            .RunAsync(args);
        
}
```

### 3. Add a command
```csharp
using Spectre.Console;
using Spectre.Console.Cli;
public class MainCommand : Command
{
    public override int Execute(CommandContext context)
    {
        AnsiConsole.WriteLine("Hello World");
        return 0;
    }
}
```

### 4. Register command with application
```csharp
public class SpectreConfiguration : ISpectreConfiguration
{
    public override void ConfigureCommandApp(in IConfigurator configurator)
    {
        configurator.AddCommand<MainCommand>("main")
            .WithDescription("Displays hello world");
    }
}
```

### 5. Register Command Setting in DI
```csharp
public class Startup : BaseStartup
{
    public override void ConfigureServices(IServiceCollection services, IConfigurationRoot configuration)
    {
        services.RegisterCommandSettingFromAssembly(Assembly.GetExecutingAssembly());
    }
    public override int Execute(CommandContext context)
    {
        AnsiConsole.WriteLine("Hello World");
        return 0;
    }
}
```
### 6. Run the command
Run the command by using dotnet cli
```bash
> dotnet run main
Hello World
```

## Additional options
You can load configurations from a json file by just adding a file appsettings.json file and adding it to csproj file like following
```xml
<ItemGroup>
    <None Update="appsettings.json">
        <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
    </None>
</ItemGroup>
```