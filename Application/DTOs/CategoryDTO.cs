using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage="The name is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        [Display(Name="Name")]
        public string Name { get; set; }
    }
}
