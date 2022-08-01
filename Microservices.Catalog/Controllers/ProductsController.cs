using Microservices.Catalog.Cqrs.Handlers;
using Microservices.Catalog.Models.Api;
using Microsoft.AspNetCore.Mvc;

namespace Microservices.Catalog.Controllers
{
    /// <summary>
    /// Работа с каталогом товаров
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        /// <summary>
        /// Получить краткую информацию о товарах
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<GetProductsResponse>> GetProducts(
            [FromQuery] GetProductsRequest request,
            [FromServices] GetProductsQueryHandler handler)
        {
            var result = await handler.HandleAsync(request);
            if (result.IsFailure)
                return BadRequest();

            return Ok(result.Value);
        }

        [HttpGet("{productId:int}")]
        public async Task<ActionResult<GetProductsResponse>> GetProduct(
            [FromRoute] GetProductRequest request,
            [FromServices] GetProductQueryHandler handler)
        {
            var result = await handler.HandleAsync(request);
            if (result.IsFailure)
                return BadRequest();

            return Ok(result.Value);
        }
    }
}
