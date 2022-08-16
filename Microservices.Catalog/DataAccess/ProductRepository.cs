using Bogus;
using Core.General;
using Microservices.Catalog.Cqrs.Queries;
using Microservices.Catalog.Domain.Entities;
using Microservices.Catalog.Domain.Enums;
using Microservices.Catalog.Domain.ValueObjects;
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

        private readonly Color[] _colors = new Color[]
        {
            new Color { Id = "1", Name = "Red", Hex = "#FF0000" },
            new Color { Id = "2", Name = "Magenta", Hex = "#FF00FF" },
            new Color { Id = "3", Name = "Khaki", Hex = "#F0E68C" },
            new Color { Id = "4", Name = "PaleGreen", Hex = "#98FB98" },
            new Color { Id = "5", Name = "Orchid", Hex = "#DA70D6" },
            new Color { Id = "6", Name = "Black", Hex = "#000000" },
            //new Color { Id = 7, Name = "White", Hex = "#FFFFFF" },
        };

        private readonly Brand[] _brands = new Brand[]
        {
            new Brand { Id = "1", Name = "Chanel", LogoUrl = "/assets/images/chanel-logo.svg" },
            new Brand { Id = "2", Name = "Burberry", LogoUrl = "/assets/images/burberry-logo.svg" },
            new Brand { Id = "3", Name = "Dior", LogoUrl = "/assets/images/dior-logo.svg" },
            new Brand { Id = "4", Name = "Fendi", LogoUrl = "/assets/images/fendi-logo.svg" },
            new Brand { Id = "5", Name = "Versace", LogoUrl = "/assets/images/versace-logo.svg" },
            new Brand { Id = "6", Name = "Gucci", LogoUrl = "/assets/images/gucci-logo.svg" },
            new Brand { Id = "7", Name = "Armani", LogoUrl = "/assets/images/armani-logo.svg" },
        };

        private readonly string[] _sizes = new string[] { "XS", "S", "L", "M", "XL", "XXL" };

        public Task<Result<GetProductQueryResult>> GetProductAsync(GetProductQuery query)
        {
            var colors = GetSomeColors(query.ProductId).ToArray();
            var sizes = GetSizes(query.ProductId).ToArray();
            var result = Result.Ok(new GetProductQueryResult
            {
                Product = new ProductFullModel
                {
                    Id = query.ProductId,
                    Name = Faker.Commerce.ProductName(),
                    Brand = Faker.PickRandom(_brands).Name,
                    Category = Faker.PickRandom<Category>(),
                    Audience = Faker.PickRandom<Audience>(),
                    Price = Math.Round(Faker.Random.Decimal(50, 500), 2),
                    AvailableColors = GetSomeColors(query.ProductId).ToArray(),
                    ColorId = colors[0].ColorId,
                    Code = Faker.Commerce.Ean13(),
                    Description = Faker.Commerce.ProductDescription(),
                    AdditionalInfo = Faker.Commerce.ProductDescription(),
                    CoverImageUrl = $"https://placekitten.com/{Faker.Random.Int(300, 600)}/{Faker.Random.Int(600, 1200)}",
                    ImageGallery = GetSomeImageUrls().ToArray(),
                    Attributes = new[]
                    {
                        new ProductAttribute { Name = "DressLength", Value = "Short" },
                        new ProductAttribute { Name = "ManufacturerCountry", Value = "France" },
                    },
                    AvailableSizes = sizes,
                    Size = Faker.PickRandom(sizes.Where(s => s.Available)).Size
                }
            }); ; ;
            return Task.FromResult(result);
        }

        public Task<Result<GetProductsQueryResult>> GetProductsAsync(GetProductsQuery request)
        {
            /// WARN: stub
            if (request.Page > 20)
            {
                var list = new GetProductsQueryResult
                {
                    Page = request.Page,
                    PageSize = request.Page,
                    TotalPages = 20
                };
                return Task.FromResult(Result.Ok(list));
            }

            var products = new List<ProductShortModel>();
            for (int i = 0; i < request.PageSize; i++)
            {
                var colors = GetSomeColors(i + 1).ToArray();
                products.Add(new ProductShortModel
                {
                    Id = i + 1,
                    Name = Faker.Commerce.ProductName(),
                    Brand = Faker.PickRandom(_brands).Name,
                    Category = Faker.PickRandom<Category>(),
                    Audience = Faker.PickRandom<Audience>(),
                    Price = Math.Round(Faker.Random.Decimal(50, 500), 2),
                    AvailableColors = colors,
                    ColorId = colors[0].ColorId
                });
            }
            var result = Result.Ok(new GetProductsQueryResult
            {
                Page = request.Page,
                PageSize = request.PageSize,
                TotalPages = 20,
                Products = products
            });
            return Task.FromResult(result);
        }

        private IEnumerable<ColoredProductModel> GetSomeColors(int productId)
        {
            var result = new List<ColoredProductModel>();
            for (int i = 0; i < Faker.Random.Int(1, 5); i++)
            {
                var color = Faker.PickRandom(_colors.Where(c => !result.Select(x => x.ColorId).Contains(c.Id)));
                result.Add(new ColoredProductModel
                {
                    ColorId = color.Id,
                    ColorName = color.Name,
                    ProductId = i == 0 ? productId : productId * 10 + i,
                    ColorHex = color.Hex,
                    ImageUrl = $"https://placekitten.com/{Faker.Random.Int(300, 600)}/{Faker.Random.Int(600, 1200)}"
                });
            }
            return result;
        }

        private IEnumerable<string> GetSomeImageUrls()
        {
            for (int i = 0; i < Faker.Random.Int(1, 14); i++)
            {
                yield return $"https://placekitten.com/{Faker.Random.Int(480, 720)}/{Faker.Random.Int(720, 1200)}";
            }
        }

        private IEnumerable<SizedProductModel> GetSizes(int productId)
        {
            for (int i = 0; i < _sizes.Length; i++)
            {
                yield return new SizedProductModel
                {
                    ProductId = productId * 10 + i,
                    Size = _sizes[i],
                    Available = Faker.PickRandom(new bool[] { true, false })
                };
            }
        }
    }
}