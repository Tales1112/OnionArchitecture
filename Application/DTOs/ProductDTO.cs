using Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="The Name is Required")]
        [MinLength(1)]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required(ErrorMessage ="The Description is Required")]
        [MinLength(5)]
        [MaxLength(200)]
        public string Description { get; set; }
        
        [Required(ErrorMessage = "The Price is Required")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "The Stock is Required")]
        [Range(1, 9999)]
        public int Stock { get; set; }
        [MaxLength(250)]
        public string Image { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
