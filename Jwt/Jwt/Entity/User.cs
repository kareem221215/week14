using System.ComponentModel.DataAnnotations;

namespace identity_and_data_protection.Entity
{
    public class User
    {
        public int Id { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }
    }
}
