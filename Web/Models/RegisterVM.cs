using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class RegisterVM
    {
        /// <summary>
        /// First name of the user
        /// </summary>
        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Last name of the user
        /// </summary>
        [Required]
        [Display(Name = "Last name")]
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// This is email
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
        /// This is confirm password
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The Password and Confirmation does not match.")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; } = string.Empty;

    }
}
