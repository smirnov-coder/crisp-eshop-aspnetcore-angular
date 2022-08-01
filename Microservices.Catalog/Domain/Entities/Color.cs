namespace Microservices.Catalog.Domain.Entities
{
    /// <summary>
    /// Цвет товара
    /// </summary>
    public class Color : BaseEntity
    {
        /// <summary>
        /// Название цвета
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Шестнадцатиричный HEX-код
        /// </summary>
        public string Hex { get; set; }
    }
}
