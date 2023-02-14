using System;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;

namespace ZenExtensions.Spectre.Console.DependencyInjection
{
    internal sealed class TypeResolver : ITypeResolver, IDisposable
    {
        private readonly IServiceProvider _provider;

        public TypeResolver(IServiceProvider provider)
        {
            _provider = provider ?? throw new ArgumentNullException(nameof(provider));
        }

        public object? Resolve(Type? type)
        {
            ArgumentNullException.ThrowIfNull(type);
            return _provider.GetRequiredService(type);
        }

        public void Dispose()
        {
            if (_provider is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }
    }
}