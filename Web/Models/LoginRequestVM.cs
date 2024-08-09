using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class LoginRequestVM
    {
        /// <summary>
        /// This is User email
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// This is password field
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// This is is remembring last login details
        /// </summary>
        public bool RememberMe { get; set; }
    }
}
