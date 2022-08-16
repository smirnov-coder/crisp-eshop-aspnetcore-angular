using Microservices.Catalog.Domain.Entities;
using Microservices.Catalog.Domain.Enums;
using Microservices.Catalog.General;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace Microservices.Catalog.DataAccess
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMongoDb(this IServiceCollection services)
        {
            var conventions = new ConventionPack
            {
                new EnumRepresentationConvention(BsonType.String)
            };
            ConventionRegistry.Register("EnumRepresentation", conventions, t => true);

            BsonClassMap.RegisterClassMap<BaseEntity>(cm =>
            {
                cm.AutoMap();
                cm.MapIdMember(e => e.Id).SetIdGenerator(StringObjectIdGenerator.Instance);
            });
            //BsonClassMap.RegisterClassMap<Product>(cm =>
            //{
            //    cm.AutoMap();
            //    cm.MapMember(p => p.Category).SetSerializer(new EnumSerializer<Category>(BsonType.String));
            //    cm.MapMember(p => p.Audience).SetSerializer(new EnumSerializer<Audience>(BsonType.String));
            //});

            return services.AddScoped(services =>
            {
                var configuration = services.GetRequiredService<IConfiguration>();
                var mongoClient = new MongoClient(configuration.GetConnectionString(Constants.DatabaseConnectionStringKey));
                return mongoClient.GetDatabase(Constants.DatabaseName);
            });
        }
    }
}
