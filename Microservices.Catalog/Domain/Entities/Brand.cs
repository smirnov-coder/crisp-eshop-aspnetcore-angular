namespace Microservices.Catalog.Domain.Entities
{
    /// <summary>
    /// Бренд
    /// </summary>
    public class Brand : BaseEntity
    {
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Путь до файла изображения логотипа бренда
        /// </summary>
        public string LogoUrl { get; set; }
    }
}
