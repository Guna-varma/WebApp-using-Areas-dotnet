using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WeabApp_Razor.Models
{
    public class Category
    {
        [Key]
        [DisplayName("Id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [DisplayName("Category Name")]
        public string Name { get; set; }

        [DisplayName("Display order")]
        [Range(1, 2000, ErrorMessage = "Display Order should be 1- 2000")]
        public int DisplayOrder { get; set; }
    }
}
