using AuthLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthLayer.Interfaces
{
    public interface IAccountService
    {
        /// <summary>
        /// Login to the system with Email and password
        /// success returns null
        /// fail returns error message
        /// </summary>
        Task<string> Login(UserLogin model);

        /// <summary>
        /// Register new user account and set the username an email to the instance
        /// success returns true and empty string list
        /// fail returns false error list
        /// </summary>
        /// <param name="model">User registration field values</param>
        Task<(bool, List<string>)> Register(AccountRegister model);

        /// <summary>
        ///
        /// </summary>
        void Logout();
    }
}
