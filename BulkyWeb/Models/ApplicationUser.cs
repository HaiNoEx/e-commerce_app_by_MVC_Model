using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace BulkyWeb.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required]
        [DisplayName("Tên người dùng")]
        public string Name { get; set; }
        [DisplayName("Tên đường")]
        public string? StreetAddress { get; set; }
        [DisplayName("Tên tỉnh/thành phố")]
        public string? City { get; set; }
        [DisplayName("Tên quốc gia")]
        public string? State { get; set; }
        [DisplayName("Mã bưu cục")]
        public string? PostalCode { get; set; }
        public int? CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        [ValidateNever] 
        public Company? Company { get; set; }
        [NotMapped]
        public string Role { get; set; } 
    }
}
