using Core.Cqrs;

namespace Microservices.Catalog.Cqrs.Queries
{
    /// <summary>
    /// Запрос получения краткой информации о товарах
    /// </summary>
    public class GetProductsQuery : IQuery
    {
        /// <summary>
        /// Номер страницы
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Размер страницы
        /// </summary>
        public int PageSize { get; set; }
    }
}
