using System;
using System.Collections.Generic;

namespace ProductInventoryAPI.Models
{
    public class Variant
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }


        public List<SubVariant> SubVariants { get; set; }
    }
}
