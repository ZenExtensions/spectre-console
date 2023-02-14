using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;

namespace ZenExtensions.Spectre.Console.Extensions
{
    internal static class ConfigurationExtensions
    {
        public static HostingEnvironment GetHostingEnvironment(this IConfiguration configuration)
        {
            var hostingEnvironment = new HostingEnvironment
            {
                EnvironmentName = configuration[HostDefaults.EnvironmentKey] ?? Environments.Production,
                ContentRootPath = resolveContentRootPath(configuration[HostDefaults.ContentRootKey]!, AppContext.BaseDirectory)
            };
            var applicationName = configuration[HostDefaults.ApplicationKey];

            if (string.IsNullOrEmpty(applicationName))
            {
                applicationName = Assembly.GetEntryAssembly()?.GetName().Name;
            }
            hostingEnvironment.ApplicationName = applicationName ?? "zenextensions-commandline-app";
            hostingEnvironment.ContentRootFileProvider = new PhysicalFileProvider(hostingEnvironment.ContentRootPath);
            return hostingEnvironment;
        }

        private static string resolveContentRootPath(string contentRootPath, string basePath)
        {
            if (string.IsNullOrEmpty(contentRootPath))
            {
                return basePath;
            }
            if (Path.IsPathRooted(contentRootPath))
            {
                return contentRootPath;
            }
            return Path.Combine(Path.GetFullPath(basePath), contentRootPath);
        }
    }
}