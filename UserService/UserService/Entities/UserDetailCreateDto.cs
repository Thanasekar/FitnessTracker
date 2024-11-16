using System.ComponentModel.DataAnnotations;

namespace UserService.Entities
{
    public class UserDetailCreateDto
    {
        
        [Required(ErrorMessage = "This field is required")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "This field should only contain alphabets")]
        [MaxLength(30, ErrorMessage = "Only 30 characters are allowed")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "This field should only contain alphabets")]
        [MaxLength(30, ErrorMessage = "Only 30 characters are allowed")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Please provide a valid phone number")]
        public long Phone { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [EmailAddress(ErrorMessage = "Please provide a valid email address")]
        public string Email { get; set; } = string.Empty;
    }
}
