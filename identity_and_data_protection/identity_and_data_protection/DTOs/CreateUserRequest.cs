using System.ComponentModel.DataAnnotations;

namespace identity_and_data_protection.DTOs
{
    public class CreateUserRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }

}
