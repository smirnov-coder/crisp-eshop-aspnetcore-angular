using Refit;
using Web.ClientUI.Models.Api;

namespace Web.ClientUI.ApiClients
{
    public interface ICatalogApiClient
    {
        [Get("/api/products")]
        Task<IApiResponse<GetProductsResponse>> GetProductsAsync(GetProductsRequest request);

        [Get("/api/products/{request.productId}")]
        Task<IApiResponse<GetProductResponse>> GetProductAsync(GetProductRequest request);
    }
}
