using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class DepartmentVM
    {
        public long DepartmentId { get; set; } 

        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Description { get; set; }

        public DateTime AddedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
