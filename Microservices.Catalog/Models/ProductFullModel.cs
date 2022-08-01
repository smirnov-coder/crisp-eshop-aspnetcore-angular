using Microservices.Catalog.Domain.Entities;

namespace Microservices.Catalog.Models
{
    public class ProductFullModel : ProductShortModel
    {
        public string Code { get; set; }

        public string CoverImageUrl { get; set; }

        public string[] ImageGallery { get; set; }

        public string Description { get; set; }

        public string AdditionalInfo { get; set; }

        public ProductAttribute[] Attributes { get; set; }

        public SizedProductModel[] AvailableSizes { get; set; }

        public string Size { get; set; }
    }
}
