using System.ComponentModel.DataAnnotations;

namespace EssentialsSupps_Backend.Application.DTOs
{
    public class ProductDto
    {
        public int IdProduct { get; set; }
        public required string CodeProduct { get; set; }
        public required string NameProduct { get; set; }
        public string? DescriptionProduct { get; set; }
        public decimal PriceProduct { get; set; }
        public int Stock { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
    public class ProductCreateDto
    {
        [Required(ErrorMessage = "Product needs code")]
        [StringLength(255, ErrorMessage = "CodeProduct must be less than 255 characters")]
        public required string CodeProduct { get; set; }
        [Required(ErrorMessage = "Product needs name")]
        [StringLength(255, ErrorMessage = "NameProduct must be less than 255 characters")]
        public required string NameProduct { get; set; }
        [StringLength(255, ErrorMessage = "DescriptionProduct must be less than 255 characters")]
        public string DescriptionProduct { get; set; } = string.Empty;
        [Required(ErrorMessage = "Product needs price")]
        [Range(0.01, double.MaxValue, ErrorMessage = "PriceProduct must be greater than 0")]
        public decimal PriceProduct { get; set; }
        [Required(ErrorMessage = "Product needs stock")]
        public int Stock { get; set; }

    }

    public class ProductUpdateDto
    {
        [Required(ErrorMessage = "Product needs code")]
        [StringLength(255, ErrorMessage = "CodeProduct must be less than 255 characters")]
        public string CodeProduct { get; set; }
        [Required(ErrorMessage = "Product needs name")]
        [StringLength(255, ErrorMessage = "NameProduct must be less than 255 characters")]
        public string NameProduct { get; set; }
        [StringLength(255, ErrorMessage = "DescriptionProduct must be less than 255 characters")]
        public string DescriptionProduct { get; set; } = string.Empty;
        [Required(ErrorMessage = "Product needs price")]
        [Range(0.01, double.MaxValue, ErrorMessage = "PriceProduct must be greater than 0")]
        public decimal PriceProduct { get; set; }
        [Required(ErrorMessage = "Product needs stock")]
        public int Stock { get; set; }
        public bool IsActive { get; set; } = true;

    }

    public class ProductDetailDto
    {
        public int IdProduct{ get; set; }
        public required string CodeProduct { get; set; }
        public required string NameProduct { get; set; }
        public string? DescriptionProduct { get; set; }
        public decimal PriceProduct { get; set; }
        public int Stock { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }

    public class ProductListDto
    {
        public int IdProduct { get; set; }
        public required string NameProduct { get; set; }
        public decimal PriceProduct { get; set; }
        public int Stock { get; set; }
        public bool IsActive { get; set; }
    }
}
