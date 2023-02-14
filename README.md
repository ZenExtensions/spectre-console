# Zen Spectre Console Extensions
[![Actions Status](https://github.com/ZenExtensions/spectre-console/workflows/.NET%20Core%20Build/badge.svg?branch=main)](https://github.com/ZenExtensions/spectre-console/actions) [![Actions Status](https://github.com/ZenExtensions/spectre-console/workflows/.NET%20Core%20Publish/badge.svg)](https://github.com/ZenExtensions/spectre-console/actions) [![Current Version](https://img.shields.io/badge/Version-1.5.0-brightgreen?logo=nuget&labelColor=30363D)](./CHANGELOG.md#100---2023-02-15)

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
using ZenExtensions.Spectre.Console;

public class Startup : BaseStartup
{
    public abstract void ConfigureServices(IServiceCollection services, IConfiguration configuration, IHostEnvironment hostingEnvironment)
    {

    }

    public override void ConfigureCommands(in IConfigurator configurator)
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
    public static Task<int> Main(string[] args) => 
        CliHost.RunAsync<Startup>(args);
}
```
You can also have a default command using generic SpectreConsoleHost.
```csharp
using ZenExtensions.Spectre.Console;
using System.Threading.Tasks;

class Program
{
    public static Task<int> RunWithMainCommandAsync(string[] args) => 
        CliHost.RunAsync<Startup>(args);
        
}
```

### 3. Add a command
```csharp
using Spectre.Console;
using Spectre.Console.Cli;
using ZenExtensions.Spectre.Console;
public class MainCommand : ZenCommand
{
    public override void OnExecute(CommandContext context, CancellationToken cancellationToken)
    {
        Terminal.WriteLine("Hello World");
    }
}
```

### 4. Register command with application
```csharp
using ZenExtensions.Spectre.Console;

public class Startup : BaseStartup
{
    public abstract void ConfigureServices(IServiceCollection services, IConfiguration configuration, IHostEnvironment hostingEnvironment)
    {

    }

    public override void ConfigureCommands(in IConfigurator configurator)
    {
        configurator.AddCommand<MainCommand>("main")
            .WithDescription("Displays hello world");
    }
}
```
### 5. Run the command
Run the command by using dotnet cli
```bash
> dotnet run main
Hello World
```