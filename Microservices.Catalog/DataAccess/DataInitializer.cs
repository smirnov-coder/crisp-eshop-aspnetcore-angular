using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Bogus;
using Microservices.Catalog.Domain.Entities;
using Microservices.Catalog.Domain.Enums;
using Microservices.Catalog.General;
using Microservices.Catalog.Services;
using MongoDB.Driver;

namespace Microservices.Catalog.DataAccess
{
    public static class DataInitializer
    {
        private static readonly Faker Faker = new() { Random = new Randomizer(12345) };

        public static async Task InitializeAsync(IServiceProvider services)
        {
            var configuration = services.GetRequiredService<IConfiguration>();
            var environment = services.GetRequiredService<IWebHostEnvironment>();
            var fileService = services.GetRequiredService<IFileService>();
            var db = services.GetRequiredService<IMongoDatabase>();

            await EnsureBlobContainersCreatedAsync(configuration);
            await CreateBrandsAsync(db, environment, fileService);
            await CreateColorsAsync(db);
            await CreateProductsAsync(db);
        }

        private static Task EnsureBlobContainersCreatedAsync(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(Constants.CloudStorageConfigurationKey);
            var serviceClient = new BlobServiceClient(connectionString);
            var containerClient = serviceClient.GetBlobContainerClient(Constants.BlobContainerName);
            return containerClient.CreateIfNotExistsAsync(PublicAccessType.Blob);
        }

        private static async Task CreateBrandsAsync(IMongoDatabase db, IWebHostEnvironment environment, IFileService fileService)
        {
            var brands = db.GetCollection<Brand>(Constants.BrandsCollectionName);
            if (brands.EstimatedDocumentCount() > 0)
                return;

            var imageDirectory = Path.Combine(environment.ContentRootPath, "DataAccess", "Images");
            if (!Directory.Exists(imageDirectory))
                throw new DirectoryNotFoundException($"Directory {imageDirectory} not found.");

            var brandsData = new Brand[]
            {
                new Brand { Name = "Chanel", LogoUrl = await SaveImageAsync(imageDirectory, "chanel-logo.svg", fileService) },
                new Brand { Name = "Burberry", LogoUrl = await SaveImageAsync(imageDirectory, "burberry-logo.svg", fileService) },
                new Brand { Name = "Dior", LogoUrl = await SaveImageAsync(imageDirectory, "dior-logo.svg", fileService) },
                new Brand { Name = "Fendi", LogoUrl = await SaveImageAsync(imageDirectory, "fendi-logo.svg", fileService) },
                new Brand { Name = "Versace", LogoUrl = await SaveImageAsync(imageDirectory, "versace-logo.svg", fileService) },
                new Brand { Name = "Gucci", LogoUrl = await SaveImageAsync(imageDirectory, "gucci-logo.svg", fileService) },
                new Brand { Name = "Armani", LogoUrl = await SaveImageAsync(imageDirectory, "armani-logo.svg", fileService) },
            };
            await brands.InsertManyAsync(brandsData);
        }

        private static Task<string> SaveImageAsync(string directory, string fileName, IFileService fileService)
        {
            var filePath = Path.Combine(directory, fileName);
            return fileService.SaveImageAsync(File.OpenRead(filePath), Path.GetExtension(fileName));
        }

        private static Task CreateColorsAsync(IMongoDatabase db)
        {
            var colors = db.GetCollection<Color>(Constants.ColorsCollectionName);
            if (colors.EstimatedDocumentCount() > 0)
                return Task.CompletedTask;

            var colorsData = new Color[]
            {
                new Color { Name = "Red", Hex = "#FF0000" },
                new Color { Name = "Magenta", Hex = "#FF00FF" },
                new Color { Name = "Khaki", Hex = "#F0E68C" },
                new Color { Name = "PaleGreen", Hex = "#98FB98" },
                new Color { Name = "Orchid", Hex = "#DA70D6" },
                new Color { Name = "Black", Hex = "#000000" },
            };
            return colors.InsertManyAsync(colorsData);
        }

        private static Task CreateProductsAsync(IMongoDatabase db)
        {
            var products = db.GetCollection<Product>(Constants.ProductsCollectionName);
            if (products.EstimatedDocumentCount() > 0)
                return Task.CompletedTask;

            var productsData = new List<Product>();
            var brands = db.GetCollection<Brand>(Constants.BrandsCollectionName)
                .Find(FilterDefinition<Brand>.Empty)
                .ToList();
            var colors = db.GetCollection<Color>(Constants.ColorsCollectionName)
                .Find(FilterDefinition<Color>.Empty)
                .ToList();
            var sizes = new string[] { "XS", "S", "L", "M", "XL", "XXL", "XXXL" };
            foreach (var (audience, category) in GetPairs())
            {
                var codes = new string[10];
                Array.Fill(codes, Faker.Commerce.Ean13());

                for (int i = 0; i < 10; i++)
                {
                    var brand = Faker.PickRandom(brands);
                    var color = Faker.PickRandom(colors);
                    productsData.Add(new Product
                    {
                        Name = Faker.Commerce.ProductName(),
                        Brand = brand,
                        Category = category,
                        Audience = audience,
                        Price = Math.Round(Faker.Random.Decimal(50, 500), 2),
                        Color = color,
                        Code = Faker.PickRandom(codes),
                        Description = Faker.Commerce.ProductDescription(),
                        AdditionalInfo = Faker.Commerce.ProductDescription(),
                        CoverImageUrl = $"https://placekitten.com/{Faker.Random.Int(300, 600)}/{Faker.Random.Int(600, 1200)}",
                        ImageGallery = GetSomeImageUrls().ToArray(),
                        Size = Faker.PickRandom(sizes),
                        StockQuantity = Faker.Random.Int(0, 50)
                    });
                }
            }

            productsData = Faker.Random.Shuffle(productsData).ToList();
            return products.InsertManyAsync(productsData);
        }

        private static IEnumerable<(Audience, Category)> GetPairs()
        {
            var menCategories = new[]
            {
                Category.Jacket,
                Category.Trousers,
                Category.Suit,
                Category.Shirt
            };
            var menPairs = menCategories.Select(c => (Audience.Men, c)).ToList();
            var womenPairs = Enum.GetValues<Category>().Select(c => (Audience.Women, c)).ToList();

            return menPairs.Concat(womenPairs);
        }

        private static IEnumerable<string> GetSomeImageUrls()
        {
            for (int i = 0; i < Faker.Random.Int(1, 14); i++)
            {
                yield return $"https://placekitten.com/{Faker.Random.Int(480, 720)}/{Faker.Random.Int(720, 1200)}";
            }
        }
    }
}
