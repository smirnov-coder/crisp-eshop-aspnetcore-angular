using Microservices.Catalog.Domain.Entities;

namespace Microservices.Catalog.Domain.ValueObjects
{
    /// <summary>
    /// Товар, доступный в другом цвете
    /// </summary>
    public class ColoredProduct
    {
        /// <summary>
        /// Идентификатор товара
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        /// Идентификатор цвета
        /// </summary>
        public string ColorId { get; set; }

        /// <summary>
        /// Название цвета
        /// </summary>
        public string ColorName { get; set; }

        /// <summary>
        /// HEX-код цвета
        /// </summary>
        public string ColorHex { get; set; }

        /// <summary>
        /// Путь до файла изображения товара в заданном цвете
        /// </summary>
        public string ImageUrl { get; set; }

        public ColoredProduct(Product product)
        {
            ProductId = product.Id;
            ColorId = product.Color.Id;
            ColorName = product.Color.Name;
            ColorHex = product.Color.Hex;
            ImageUrl = product.CoverImageUrl;
        }
    }
}
