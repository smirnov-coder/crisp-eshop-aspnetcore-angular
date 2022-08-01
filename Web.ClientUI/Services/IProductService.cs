using Core.General;
using Web.ClientUI.Models;
using Web.ClientUI.Models.Api;

namespace Web.ClientUI.Services
{
    public interface IProductService
    {
        Task<Result<GetProductsResponse>> GetProductsAsync(GetProductsRequest request);

        Task<Result<GetProductResponse>> GetProductAsync(GetProductRequest request);
    }
}
