﻿using System.ComponentModel.DataAnnotations.Schema;

namespace OneStore.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18, 2))")]
        public decimal Price { get; set; }
        [Column(TypeName = "decimal(18, 2))")]
        public decimal? DiscountPrice { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }

        public Category? Category { get; set; }
    }
}
