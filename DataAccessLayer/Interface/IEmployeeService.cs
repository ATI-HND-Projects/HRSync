using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllEmployee();

        Task<Employee> GetEmployeeById(long id);

        Task<string> AddEmployee(Employee model);

        Task<string> UpdateEmployee(Employee model);

        Task<string> DeleteEmploye(long id);
    }
}
