using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    public interface IDepartmentService
    {
        Task<List<Department>> GetAllDepartment();

        Task<Department> GetDepartmentById(long id); 
        
        Task<string> AddDepartment(Department model);

        Task<string> UpdateDepartment(Department model);

        Task<string> DeleteDepartment(long id);
    }
}
