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
        public ColoredProductModel[] AvailableColors { get; set; }
    }
}
