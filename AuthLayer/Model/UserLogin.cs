using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthLayer.Model
{
    public class UserLogin
    {
        /// <summary>
        /// This is User email
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// This is password field
        /// </summary>
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// This is is remembring last login details
        /// </summary>
        public bool RememberMe { get; set; }

    }
}
