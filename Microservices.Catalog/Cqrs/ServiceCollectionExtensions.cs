using System.Reflection;

namespace Microservices.Catalog.Cqrs
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCqrsHandlers(this IServiceCollection services)
        {
            Assembly.GetExecutingAssembly()
                .DefinedTypes
                .Where(t => t.BaseType?.Name.Contains("HandlerBase") == true)
                .ToList()
                .ForEach(type => services.AddTransient(type));

            return services;
        }
    }
}
