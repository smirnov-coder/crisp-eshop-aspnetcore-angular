using Core.Cqrs;
using Core.General;
using Microservices.Catalog.Cqrs.Queries;
using Microservices.Catalog.DataAccess;
using Microservices.Catalog.Models;

namespace Microservices.Catalog.Cqrs.Handlers
{
    public class GetProductQueryHandler : QueryHandlerBase<GetProductQuery, GetProductQueryResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<GetProductsQueryHandler> _logger;

        public GetProductQueryHandler(IProductRepository productRepository, ILogger<GetProductsQueryHandler> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        public override async Task<Result<GetProductQueryResult>> HandleAsync(GetProductQuery query)
        {
            var result = await _productRepository.GetProductAsync(query);
            if (result.IsFailure)
            {
                _logger.LogError($"Ошибка при получении информации о товаре Id={query.ProductId}.", result.Error);
                return Result.Fail<GetProductQueryResult>($"Не удалось получить информацию о товаре Id={query.ProductId}");
            }

            return result;
        }
    }
}
