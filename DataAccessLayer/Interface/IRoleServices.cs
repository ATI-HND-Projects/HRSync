using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    public interface IRoleServices
    {
        Task<List<UserRoles>> GetAllUserRoles();

        Task<UserRoles> GetUserRoleById(long id);

        Task<string> AddUserRole(UserRoles model);

        Task<string> UpdateUserRole(UserRoles model);

        Task<string> DeleteUserRole(long id);
    }
}