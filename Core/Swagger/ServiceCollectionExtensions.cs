using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Core.Swagger
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Добавляет кастомную настройку Swagger
        /// </summary>
        /// <param name="swaggerDocTitle">Заголовок страницы документации Swagger</param>
        /// <param name="swaggerDocVersion">Версия описания API</param>
        public static IServiceCollection AddSwaggerGen(this IServiceCollection services, string assemblyName, string swaggerDocTitle, string swaggerDocVersion = "v1")
        {
            return services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(swaggerDocVersion, new OpenApiInfo
                {
                    Version = swaggerDocVersion,
                    Title = swaggerDocTitle,
                });
                var xmlFilename = $"{assemblyName}.xml";
                var xmlFilePath = Path.Combine(AppContext.BaseDirectory, xmlFilename);
                options.IncludeXmlComments(xmlFilePath);

                // Вывод значений перечислений с описанием
                options.SchemaFilter<EnumTypesSchemaFilter>(xmlFilePath);
            });
        }
    }
}
