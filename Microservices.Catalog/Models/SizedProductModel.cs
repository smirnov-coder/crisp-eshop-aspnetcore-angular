using Microservices.Catalog.Domain.ValueObjects;

namespace Microservices.Catalog.Models
{
    public class SizedProductModel
    {
        public string ProductId { get; set; }

        public string Size { get; set; }

        public bool Available { get; set; }

        public SizedProductModel(SizedProduct product)
        {
            ProductId = product.ProductId;
            Size = product.Size;
        }
    }
}
