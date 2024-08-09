using DataAccessLayer.Data;
using DataAccessLayer.Interface;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Services
{
    //public class EmployeeService : IEmployeeService
    //{
    //    private readonly AppDbContect _dbContext;

    //    public EmployeeService(AppDbContext dbContext)
    //    {
    //        _dbContext = dbContext;
    //    }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <returns></returns>
    //    public async Task<List<Employee>> GetAllEmployee()
    //    {
    //        var result = await _dbContext.Tbl_Employee.ToListAsync();

    //        if (result.Any())
    //            return result;

    //        return new List<Employee>();
    //    }

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <param name="id"></param>
    //    /// <returns></returns>
    //    public async Task<Employee> GetEmployeeById(long id)
    //    {

    //    }

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <param name="model"></param>
    //    /// <returns></returns>
    //    public async Task<string> AddEmployee(Employee model)
    //    {

    //    }

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <param name="model"></param>
    //    /// <returns></returns>
    //    public async Task<string> UpdateEmployee(Employee model)
    //    {

    //    }

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <param name="id"></param>
    //    /// <returns></returns>
    //    public async Task<string> DeleteEmploye(long id)
    //    {

    //    }
    //}
}
