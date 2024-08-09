using DataAccessLayer.Data;
using DataAccessLayer.Interface;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Services
{
    public class RoleServices : IRoleServices
    {
        private readonly AppDbContext _dbContext;

        public RoleServices(AppDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<UserRoles>> GetAllUserRoles()
        {
            var result = await _dbContext.Tbl_UserRole.ToListAsync();

            if (result.Any())
                return result;

            return new List<UserRoles>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        /// 
        public async Task<UserRoles> GetUserRoleById(long id)
        {
            var result = await _dbContext.Tbl_UserRole.FirstOrDefaultAsync(x => x.RoleId.Equals(id));

            if (result != null)
                return result;

            return new UserRoles();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        /// 
        public async Task<string> AddUserRole(UserRoles model)
        {
            model.AddedDate = DateTime.Now;

            _dbContext.Tbl_UserRole.Add(model);

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
        public async Task<string> UpdateUserRole(UserRoles model)
        {
            model.UpdatedDate = DateTime.Now;

            _dbContext.Tbl_UserRole.Update(model);

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
        public async Task<string> DeleteUserRole(long id)
        {
            var found = await _dbContext.Tbl_UserRole.FindAsync(id);

            if (found == null)
                return "No Records found to delete!";

            _dbContext.Tbl_UserRole.Remove(found);

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

