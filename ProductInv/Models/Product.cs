using System;
using System.Collections.Generic;

namespace ProductInventoryAPI.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public byte[]? ProductImage { get; set; } // Allow null
        public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset UpdatedDate { get; set; } = DateTimeOffset.UtcNow;
        public Guid CreatedUser { get; set; }
        public bool IsFavourite { get; set; }
        public bool Active { get; set; }
        public string HSNCode { get; set; }
        public decimal TotalStock { get; set; }

        public List<Variant> Variants { get; set; }
    }
}
