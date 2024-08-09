using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class EmployeeVM
    {
        public long EmpId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get;set; }

        [Required]
        public DateOnly DOB { get; set; }

        [Required]
        public string JobTitle { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime AddedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public bool IsActive { get; set; }
    }
}
