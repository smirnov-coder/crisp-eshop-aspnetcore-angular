using Bogus;
using Core.General;
using Microservices.Catalog.Cqrs.Queries;
using Microservices.Catalog.Domain.Entities;
using Microservices.Catalog.General;
using Microservices.Catalog.Models;
using MongoDB.Driver;

namespace Microservices.Catalog.DataAccess
{
    public class ProductRepository : IProductRepository
    {
        private static readonly Faker Faker = new() { Random = new Randomizer(1234) };
        private readonly IMongoDatabase _db;

        public ProductRepository(IMongoDatabase db)
        {
            _db = db;
        }

        public Task<Result<GetProductQueryResult>> GetProductAsync(GetProductQuery query)
        {
            var collection = _db.GetCollection<Product>(Constants.ProductsCollectionName);
            var product = collection.AsQueryable().SingleOrDefault(p => p.Id == query.ProductId);
            var result = new GetProductQueryResult { Product = product is null ? null : new ProductFullModel(product) };
            if (result.Product is null)
                return Task.FromResult(Result.Ok(result));

            var availableSizes = collection.AsQueryable()
                .Where(p => p.Code == product.Code)
                .Select(p => new { p.Id, Available = p.StockQuantity > 0 })
                .ToList();
            foreach (var sizedProduct in result.Product.AvailableSizes)
            {
                sizedProduct.Available = availableSizes.FirstOrDefault(x => x.Id == sizedProduct.ProductId)?.Available ?? false;
            }

            return Task.FromResult(Result.Ok(result));
        }

        public async Task<Result<GetProductsQueryResult>> GetProductsAsync(GetProductsQuery query)
        {
            var collection = _db.GetCollection<Product>(Constants.ProductsCollectionName);
            var products = collection.AsQueryable()
                .Skip((query.Page - 1) * query.PageSize)
                .Take(query.PageSize)
                .Select(p => new ProductShortModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Brand = p.Brand.Name,
                    Price = p.Price,
                    ColorId = p.Color.Id,
                    Audience = p.Audience,
                    Category = p.Category,
                    AvailableColors = p.AvailableColors
                        .Select(c => new ColoredProductModel
                        {
                            ProductId = c.ProductId,
                            ColorId = c.ColorId,
                            ColorName = c.ColorName,
                            ColorHex = c.ColorHex,
                            ImageUrl = c.ImageUrl
                        })
                })
                .ToList();

            var totalPages = (int)Math.Ceiling(await collection.EstimatedDocumentCountAsync() / query.PageSize * 1d);
            var result = Result.Ok(new GetProductsQueryResult
            {
                Page = query.Page,
                PageSize = query.PageSize,
                TotalPages = totalPages,
                Products = products
            });

            return result;
        }
    }
}