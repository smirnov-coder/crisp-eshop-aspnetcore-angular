using Core.General;
using Microservices.Catalog.Cqrs.Queries;

namespace Microservices.Catalog.DataAccess
{
    public interface IProductRepository
    {
        Task<Result<GetProductsQueryResult>> GetProductsAsync(GetProductsQuery query);

        Task<Result<GetProductQueryResult>> GetProductAsync(GetProductQuery query);
    }
}
