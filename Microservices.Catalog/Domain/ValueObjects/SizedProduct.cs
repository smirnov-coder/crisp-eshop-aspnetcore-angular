using Microservices.Catalog.Domain.Entities;

namespace Microservices.Catalog.Domain.ValueObjects
{
    public class SizedProduct
    {
        public string ProductId { get; set; }

        public string Size { get; set; }

        public SizedProduct(Product product)
        {
            ProductId = product.Id;
            Size = product.Size;
        }
    }
}
