using System.ComponentModel.DataAnnotations;

namespace Informatic_API.DTO
{
    public class PhoneNumberDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [MaxLength(11, ErrorMessage ="Phone Number Must Be Exact 11 number")]
        [MinLength(11,ErrorMessage = "Phone Number Must Be Exact 11 number")]
        public string PhoneNumber { get; set; }
    }
}
