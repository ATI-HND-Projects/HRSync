using AuthLayer.Interfaces;
using AuthLayer.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthLayer.Services
{
    public class AccountService : IAccountService
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserStore<AppUser> _userStore;
        private readonly IUserEmailStore<AppUser> _userEmailStore;

        public AccountService(SignInManager<AppUser> signInManager,
                              UserManager<AppUser> userManager,
                              IUserStore<AppUser> userStore)
        {
            _signInManager  = signInManager;
            _userManager    = userManager;
            _userStore      = userStore;
            _userEmailStore = GetEmailStore();
        }

        /// <summary>
        ///  
        /// </summary>
        /// <returns></returns>
        public async Task<string> Login(UserLogin model)
        {

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure:false);

            if(!result.Succeeded)
            {
                return "Invalid login attempt";
            }
            else if(result.IsLockedOut)
            {
                return "Your account is locked, please contact admin.";
            }
            else
            {
                return null;
            }

        }

        /// <summary>
        /// Register new user account and set the username an email to the instance
        /// success returns true and empty string list
        /// fail returns false error list
        /// </summary>
        /// <param name="model">User registration field values</param>
        public async Task<(bool, List<string>)> Register(AccountRegister model)
        {
            var user  = CreateUser();
            var error = new List<string>();

            user.FirstName = model.FirstName;
            user.LastName  = model.LastName;

            await _userStore.SetUserNameAsync(user, model.Email, CancellationToken.None);
            await _userEmailStore.SetEmailAsync(user, model.Email, CancellationToken.None);

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                foreach (var e in result.Errors)
                {
                    error.Add(e.Description);
                }

                return (false, error);
            }

            return (true, error);
        }

        /// <summary>
        /// 
        /// </summary>
        public async void Logout()
        {
            await _signInManager.SignOutAsync();
        }

        #region Helpers

        /// <summary>
        /// Create a App User Instance to use AppUser and Identity User properties
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        private AppUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<AppUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(AppUser)}'. " +
                    $"Ensure that '{nameof(AppUser)}' is not an abstract class and has a parameterless constructor");
            }
        }

        /// <summary>
        /// Get email to store
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        private IUserEmailStore<AppUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<AppUser>)_userStore;

        }

        #endregion

    }
}
