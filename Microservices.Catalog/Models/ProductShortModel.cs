using Microservices.Catalog.Domain.Entities;
using Microservices.Catalog.Domain.Enums;

namespace Microservices.Catalog.Models
{
    /// <summary>
    /// Краткая информация о товаре
    /// </summary>
    public class ProductShortModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Наименование товара
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Наименование бренда
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// Цена
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Идентификатор цвета товара
        /// </summary>
        public string ColorId { get; set; }

        /// <summary>
        /// Целевая аудитория товара
        /// </summary>
        public Audience Audience { get; set; }

        /// <summary>
        /// Категория товара
        /// </summary>
        public Category Category { get; set; }

        /// <summary>
        /// Доступные цвета товара
        /// </summary>
        public IEnumerable<ColoredProductModel> AvailableColors { get; set; }

        public string CoverImageUrl { get; set; }

        public ProductShortModel()
        {
        }

        public ProductShortModel(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Brand = product.Brand.Name;
            Price = product.Price;
            ColorId = product.Color.Id;
            Audience = product.Audience;
            Category = product.Category;
            AvailableColors = product.AvailableColors.Select(c => new ColoredProductModel(c)).ToArray();
            CoverImageUrl = product.CoverImageUrl;
        }
    }
}
