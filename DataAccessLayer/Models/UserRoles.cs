using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class UserRoles
    {
        [Key]
        public long RoleId { get; set; }

        public string Role { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
        
        public string AddedBy {  get; set; } = string.Empty;

        public string UpdatedBy { get; set; } = string.Empty;

        public DateTime AddedDate { get; set; }

        public DateTime UpdatedDate { get; set;}

        public bool IsActive { get; set; } 
    }
}
