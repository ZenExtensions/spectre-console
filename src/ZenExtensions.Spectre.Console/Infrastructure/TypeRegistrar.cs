using System;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;

namespace ZenExtensions.Spectre.Console.Infrastructure
{
    internal sealed class TypeRegistrar : ITypeRegistrar
    {
        private readonly IServiceCollection services;

        public TypeRegistrar(IServiceCollection services)
        {
            this.services = services;
        }

        public ITypeResolver Build()
        {
            return new TypeResolver(services.BuildServiceProvider());
        }

        public void Register(Type service, Type implementation)
        {
            services.AddSingleton(service,implementation);
        }

        public void RegisterInstance(Type service, object implementation)
        {
            services.AddSingleton(service,implementation);
        }

        public void RegisterLazy(Type service, Func<object> func)
        {
            if (func is null)
            {
                throw new ArgumentNullException(nameof(func));
            }
            services.AddSingleton(service,(provider) => func());
        }
    }
}