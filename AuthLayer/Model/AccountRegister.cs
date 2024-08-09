using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthLayer.Model
{
    public class AccountRegister
    {
        /// <summary>
        /// First name of the user
        /// </summary>        
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Last name of the user
        /// </summary>
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// This is email
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// This is password field
        /// </summary>
        public string Password { get; set; } = string.Empty;

    }
}
