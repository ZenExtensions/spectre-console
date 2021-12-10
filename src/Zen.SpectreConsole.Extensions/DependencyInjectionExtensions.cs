using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;

namespace Zen.SpectreConsole.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection RegisterCommandSettingFromAssembly<TClass>(this IServiceCollection services)
        {
            var assembly = typeof(TClass).GetTypeInfo().Assembly;
            services.RegisterCommandSettingFromAssembly(assembly);
            return services;
        }
        public static IServiceCollection RegisterCommandSettingFromAssembly(this IServiceCollection services, Assembly assembly)
        {
            var types = assembly.GetTypes()
                .Where(t => t.IsClass && t.IsPublic && !t.IsAbstract && t.IsSubclassOf(typeof(CommandSettings)));
            foreach (var type in types)
            {
                services.AddSingleton(type);
            }
            return services;
        }
    }
}