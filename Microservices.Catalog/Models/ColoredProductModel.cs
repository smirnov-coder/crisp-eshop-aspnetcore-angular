using Microservices.Catalog.Domain.ValueObjects;

namespace Microservices.Catalog.Models
{
    /// <summary>
    /// Товар, доступный в другом цвете
    /// </summary>
    public class ColoredProductModel
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

        public ColoredProductModel()
        {
        }

        public ColoredProductModel(ColoredProduct product)
        {
            ProductId = product.ProductId;
            ColorId = product.ColorId;
            ColorName = product.ColorName;
            ColorHex = product.ColorHex;
            ImageUrl = product.ImageUrl;
        }
    }
}
