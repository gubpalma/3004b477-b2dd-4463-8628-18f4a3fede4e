using Microsoft.Extensions.DependencyInjection;

namespace Sequence.Finder.Host.Injection
{
    internal static class ServiceCollectionExtension
    {
        public static IServiceCollection AddPlatformServices(this IServiceCollection services)
        {
            return services;
        }
    }
}