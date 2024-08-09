using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Department
    {
        [Key]
        public long DepartmentId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
        
        public string AddedById { get; set; } = string.Empty;

        public string UpdatedById { get; set; } = string.Empty;

        public DateTime AddedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

    }
}
