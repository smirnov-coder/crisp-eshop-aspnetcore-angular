using Microservices.Catalog.Models;

namespace Microservices.Catalog.Cqrs.Queries
{
    public class GetProductsQueryResult
    {
        public int Page { get; set; }

        public int PageSize { get; set; }

        public int TotalPages { get; set; }

        public IEnumerable<ProductShortModel> Products { get; set; }
    }
}
