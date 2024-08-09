using DataAccessLayer.Data;
using DataAccessLayer.Interface;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly AppDbContext _dbContext;

        public DepartmentService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<Department>> GetAllDepartment()
        {
            var result = await _dbContext.Tbl_Department.ToListAsync();

            if(result.Any())
                return result;

            return new List<Department>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Department> GetDepartmentById(long id)
        {
            var result = await _dbContext.Tbl_Department.FirstOrDefaultAsync(x => x.DepartmentId.Equals(id));

            if (result != null)
                return result;

            return new Department();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<string> AddDepartment(Department model)
        {
            model.AddedDate   = DateTime.Now;
            model.UpdatedDate = DateTime.Now;

            _dbContext.Tbl_Department.Add(model);

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<string> UpdateDepartment(Department model)
        {
            model.UpdatedDate = DateTime.Now;

            _dbContext.Tbl_Department.Update(model);

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<string> DeleteDepartment(long id)
        {
            var found = await _dbContext.Tbl_Department.FindAsync(id);

            if (found == null)
                return "No Records found to delete!";

            _dbContext.Tbl_Department.Remove(found);

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return string.Empty;
        }

    }
}
