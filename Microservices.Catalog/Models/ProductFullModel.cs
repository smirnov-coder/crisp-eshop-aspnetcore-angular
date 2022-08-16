using Microservices.Catalog.Domain.Entities;

namespace Microservices.Catalog.Models
{
    public class ProductFullModel : ProductShortModel
    {
        public string Code { get; set; }

        public IList<string> ImageGallery { get; set; }

        public string Description { get; set; }

        public string AdditionalInfo { get; set; }

        public SizedProductModel[] AvailableSizes { get; set; }

        public string Size { get; set; }

        public ProductFullModel(Product product) : base(product)
        {
            Code = product.Code;
            CoverImageUrl = product.CoverImageUrl;
            Description = product.Description;
            AdditionalInfo = product.AdditionalInfo;
            ImageGallery = product.ImageGallery;
            Size = product.Size;
            AvailableSizes = product.AvailableSizes.Select(s => new SizedProductModel(s)).ToArray();
        }
    }
}
