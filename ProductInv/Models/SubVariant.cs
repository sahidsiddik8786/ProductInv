using System;

namespace ProductInventoryAPI.Models
{
    public class SubVariant
    {
        public Guid Id { get; set; }
        public string Option { get; set; }
        public Guid VariantId { get; set; }
        public Variant Variant { get; set; }
    }
}
