using Microservices.Catalog.Models;

namespace Microservices.Catalog.Cqrs.Queries
{
    public class GetProductQueryResult
    {
        public ProductFullModel Product { get; set; }
    }
}
