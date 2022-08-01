namespace Microservices.Catalog.Domain.Entities
{
    public class ProductAttribute : BaseEntity
    {
        public string Name { get; set; }

        public object Value { get; set; }
    }
}
