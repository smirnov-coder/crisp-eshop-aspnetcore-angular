namespace Web.ClientUI.Models.Api
{
    /// <summary>
    /// Запрос на получение краткой информации о товарах постранично
    /// </summary>
    public class GetProductsRequest
    {
        public const int DefaultPageSize = 24;
        public const int MaxPageSize = 100;

        private int _page = 1;
        /// <summary>
        /// Номер страницы
        /// </summary>
        public int Page 
        {
            get => _page;
            set => _page = value < 1 ? 1 : value;
        }

        private int _pageSize = DefaultPageSize;
        /// <summary>
        /// Размер страницы
        /// </summary>
        public int PageSize 
        {
            get => _pageSize;
            set => _pageSize = value < 1 ? DefaultPageSize : value > MaxPageSize ? MaxPageSize : value;
        }
    }
}
