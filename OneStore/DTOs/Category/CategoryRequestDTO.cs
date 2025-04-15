﻿using System.ComponentModel.DataAnnotations;

namespace OneStore.DTOs.Category
{
    public class CategoryRequestDTO
    {
        [Required(ErrorMessage = "Name is required property")]
        public string Name { get; set; } = string.Empty;

        public int? ParentCategoryId { get; set; }
    }
}