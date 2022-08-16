using Microservices.Catalog.Domain.Enums;
using Microservices.Catalog.Domain.ValueObjects;

namespace Microservices.Catalog.Domain.Entities
{
    /// <summary>
    /// Товар
    /// </summary>
    public class Product : BaseEntity
    {
        /// <summary>
        /// Наименование товара
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Бренд (торговая марка)
        /// </summary>
        public Brand Brand { get; set; }

        /// <summary>
        /// Цена
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Целевая аудитория товара
        /// </summary>
        public Audience Audience { get; set; }

        /// <summary>
        /// Категория товара
        /// </summary>
        public Category Category { get; set; }

        /// <summary>
        /// Цвет товара
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// Артикул товара
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Размер
        /// </summary>
        public string Size { get; set; }

        /// <summary>
        /// Количество единиц товара на складе
        /// </summary>
        public int StockQuantity { get; set; }

        /// <summary>
        /// Описание товара
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Дополнительная информация
        /// </summary>
        public string AdditionalInfo { get; set; }

        /// <summary>
        /// Ссылка на файл главного изображения (обложки)
        /// </summary>
        public string CoverImageUrl { get; set; }

        /// <summary>
        /// Коллекция ссылок на файлы галереи товара
        /// </summary>
        public IList<string> ImageGallery { get; set; }

        public IList<ProductAttribute> Attributes { get; set; }
    }
}
