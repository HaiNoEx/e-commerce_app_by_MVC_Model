using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
		[DisplayName("Tên danh mục")]
        [MaxLength(30)]
		public string Name { get; set; }
        [DisplayName("Thứ tự hiển thị")]
        [Range(1, 100, ErrorMessage ="Range 1-100")]
        public int DisplayOrder { get; set; }
    }
}
