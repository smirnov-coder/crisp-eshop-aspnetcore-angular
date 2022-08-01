namespace Web.ClientUI.Models.Api
{
    /// <summary>
    /// Ответ на запрос получения краткой информации о товарах постранично
    /// </summary>
    public class GetProductsResponse
    {
        /// <summary>
        /// Номер страницы
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Размер страницы
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Всего страниц
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        /// Список товаров
        /// </summary>
        public IEnumerable<ProductShortModel> Products { get; set; }
    }
}
