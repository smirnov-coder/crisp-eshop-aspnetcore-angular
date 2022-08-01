using Core.General;
using Web.ClientUI.ApiClients;
using Web.ClientUI.Models.Api;

namespace Web.ClientUI.Services
{
    public class ProductService : IProductService
    {
        private readonly ICatalogApiClient _catalogClient;

        public ProductService(ICatalogApiClient catalogClient)
        {
            _catalogClient = catalogClient;
        }

        public async Task<Result<GetProductsResponse>> GetProductsAsync(GetProductsRequest request)
        {
            var apiResponse = await _catalogClient.GetProductsAsync(request);
            if (!apiResponse.IsSuccessStatusCode)
            {
                // logging ...
                return Result.Fail<GetProductsResponse>("Не удалось получить список товаров.");
            }

            return Result.Ok(apiResponse.Content);
        }

        public async Task<Result<GetProductResponse>> GetProductAsync(GetProductRequest request)
        {
            var apiResponse = await _catalogClient.GetProductAsync(request);
            if (!apiResponse.IsSuccessStatusCode)
            {
                // logging ...
                return Result.Fail<GetProductResponse>("Не удалось получить информацию о товаре.");
            }

            return Result.Ok(apiResponse.Content);
        }
    }
}
