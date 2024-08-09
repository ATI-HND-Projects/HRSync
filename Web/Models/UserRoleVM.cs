using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class UserRoleVM
    {
        public long RoleId { get; set; }

        [Required]
        public string Role { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime AddedDate { get; set; }

        public DateTime UpdatedDate { get; set;}

        public bool IsActive { get; set; }

    }
}