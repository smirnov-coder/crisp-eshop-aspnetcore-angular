using Core.Cqrs;

namespace Microservices.Catalog.Cqrs.Queries
{
    public class GetProductQuery : IQuery
    {
        public int ProductId { get; set; }
    }
}
