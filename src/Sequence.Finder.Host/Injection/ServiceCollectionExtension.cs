using Microsoft.Extensions.DependencyInjection;
using Sequence.Finder.Infrastructure;
using Sequence.Finder.Interfaces;

namespace Sequence.Finder.Host.Injection
{
    internal static class ServiceCollectionExtension
    {
        public static IServiceCollection AddPlatformServices(this IServiceCollection services)
        {
            services
                .AddTransient<ISequenceParser, SequenceParser>();

            return
                services;
        }
    }
}