using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Employee
    {
        [Key]

        public long EmpId { get; set; }

        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty ;

        [Required]
        public DateOnly DOB {  get; set; }

        [Required]
        public string JobTitle { get; set; } = string.Empty;

        [Required]
        public string Department { get; set; } = string.Empty;

        public string AddedBy { get; set; } = string.Empty;

        public string UpdatedBy { get; set; } = string.Empty;

        public DateTime AddedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public bool IsActive { get; set; }
    }
}
