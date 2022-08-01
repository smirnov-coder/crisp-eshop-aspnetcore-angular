using Core.Cqrs;
using Core.General;
using Microservices.Catalog.Cqrs.Queries;
using Microservices.Catalog.DataAccess;

namespace Microservices.Catalog.Cqrs.Handlers
{
    public class GetProductsQueryHandler : QueryHandlerBase<GetProductsQuery, GetProductsQueryResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<GetProductsQueryHandler> _logger;

        public GetProductsQueryHandler(IProductRepository productRepository, ILogger<GetProductsQueryHandler> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        public override async Task<Result<GetProductsQueryResult>> HandleAsync(GetProductsQuery query)
        {
            var result = await _productRepository.GetProductsAsync(query);
            if (result.IsFailure)
            {
                _logger.LogError("Ошибка при получении списка товаров.", result.Error);
                return Result.Fail<GetProductsQueryResult>("Не удалось получить список товаров.");
            }

            return result;
        }
    }
}
