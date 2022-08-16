using Core.Cqrs;

namespace Microservices.Catalog.Cqrs.Queries
{
    public class GetProductQuery : IQuery
    {
        public string ProductId { get; set; }
    }
}
