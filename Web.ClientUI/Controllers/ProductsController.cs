using Microsoft.AspNetCore.Mvc;
using Web.ClientUI.Models.Api;
using Web.ClientUI.Services;

namespace Web.ClientUI.Controllers
{
    /// <summary>
    /// Товары
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Получить краткую информацию о товарах постранично
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<GetProductsResponse>> GetProducts([FromQuery]GetProductsRequest request)
        {
            var result = await _productService.GetProductsAsync(request);
            if (result.IsFailure)
                return BadRequest();

            return Ok(result.Value);
        }

        [HttpGet("{productId}")]
        public async Task<ActionResult<GetProductResponse>> GetProduct([FromRoute]GetProductRequest request)
        {
            var result = await _productService.GetProductAsync(request);
            if (result.IsFailure)
                return BadRequest();

            return Ok(result.Value);
        }
    }
}
