using AuthLayer.Interfaces;
using AuthLayer.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Web.Models;

namespace Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _account;
        private readonly IMapper _mapper;

        public AccountController(IAccountService account, IMapper mapper)
        {
            _account = account;
            _mapper  = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Login()
        {
            if(User.Identity != null && User.Identity.IsAuthenticated)
            {
                return LocalRedirect("/Home/Index");
            }
            else
            {
                return View();
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestVM model)
        {
            if (ModelState.IsValid)
            {
                var data = _mapper.Map<UserLogin>(model);
                var result = await _account.Login(data);

                if (string.IsNullOrEmpty(result))
                {
                    return LocalRedirect("/Home/Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, result);
                    return View();
                }
            }
            else
            {
                return View();
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                var data = _mapper.Map<AccountRegister>(model);
                var result = await _account.Register(data);

                if (result.Item1)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (var error in result.Item2)
                    {
                        ModelState.AddModelError(string.Empty, error);
                    }

                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult Logout()
        {
             _account.Logout();

            return RedirectToAction("Login");
        }
    }
}
