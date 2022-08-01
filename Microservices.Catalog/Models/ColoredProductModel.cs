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
        public int ProductId { get; set; }

        /// <summary>
        /// Идентификатор цвета
        /// </summary>
        public int ColorId { get; set; }

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
    }
}
