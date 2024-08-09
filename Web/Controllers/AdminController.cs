using AutoMapper;
using DataAccessLayer.Interface;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Antiforgery.Internal;
using Microsoft.AspNetCore.Mvc;
using Web.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly IDepartmentService _department;
        private readonly IRoleServices _role;
        private readonly IMapper _mapper;

        public AdminController(IDepartmentService department, IRoleServices role, IMapper mapper)
        {
            _department = department;
            _role = role;
            _mapper = mapper;
        }

        public IActionResult Home()
        {
            return View();
        }


        #region Department section

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Department()
        {
            var result = await _department.GetAllDepartment();
            var data = _mapper.Map<List<DepartmentVM>>(result);

            return View(data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<PartialViewResult> AddDepartment()
        {
            return PartialView("PopUps/_AddDepartment");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> AddDepartment(DepartmentVM model)
        {
            if (ModelState.IsValid)
            {
                var data = _mapper.Map<Department>(model);
                string error = await _department.AddDepartment(data);

                if (string.IsNullOrEmpty(error))
                    return Json(new { success = true, message = "Department Created Successfuly." });

                return Json(new { success = false, message = error });
            }

            return Json(new { success = false, message = "Fields are not valid" });
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<PartialViewResult> UpdateDepartment(long id)
        {
            var found = await _department.GetDepartmentById(id);
            var data = _mapper.Map<DepartmentVM>(found);

            return PartialView("PopUps/_EditDepartment", data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> UpdateDepartment(DepartmentVM model)
        {
            if (ModelState.IsValid)
            {
                var data = _mapper.Map<Department>(model);
                string error = await _department.UpdateDepartment(data);

                if (string.IsNullOrEmpty(error))
                    return Json(new { success = true, message = "Department Updated Successfuly." });

                return Json(new { success = false, message = error });
            }

            return Json(new { success = false, message = "Fields are not valid" });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<PartialViewResult> DeleteDepartment(long id)
        {
            var found = await _department.GetDepartmentById(id);
            var data = _mapper.Map<DepartmentVM>(found);

            return PartialView("PopUps/_DeleteDepartment", data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> DeleteDepartment(DepartmentVM model)
        {
            string error = await _department.DeleteDepartment(model.DepartmentId);

            if (string.IsNullOrEmpty(error))
                return Json(new { success = true, message = "Department Deleted Successfuly." });

            return Json(new { success = false, message = error });
        }

        #endregion

        #region UserRole section 

        public async Task<IActionResult> UserRole()
        {
            var result = await _role.GetAllUserRoles();
            var data = _mapper.Map<List<UserRoleVM>>(result);

            return View(data);
        } 

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public async Task<PartialViewResult> AddUserRole()
        {
            return PartialView("PopUps/_AddUserRole");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> AddUserRole(UserRoleVM model)
        {
            if (ModelState.IsValid)
            {
                var data = _mapper.Map<UserRoles>(model);
                string error = await _role.AddUserRole(data);

                if (string.IsNullOrEmpty(error))
                    return Json(new { success = true, message = "Role Created Successfuly." });

                return Json(new { success = false, message = error });
            }

            return Json(new { success = false, message = "Fields are not valid" });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<PartialViewResult> UpdateUserRole(long id)
        {
            var found = await _role.GetUserRoleById(id);
            var data = _mapper.Map<DepartmentVM>(found);

            return PartialView("PopUps/_EditUserRole", data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> UpdateUserRole(DepartmentVM model)
        {
            if (ModelState.IsValid)
            {
                var data = _mapper.Map<UserRoles>(model);
                string error = await _role.UpdateUserRole(data);

                if (string.IsNullOrEmpty(error))
                    return Json(new { success = true, message = "UserRole Updated Successfuly." });

                return Json(new { success = false, message = error });
            }

            return Json(new { success = false, message = "Fields are not valid" });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<PartialViewResult> DeleteUserRole(long id)
        {
            var found = await _role.GetUserRoleById(id);
            var data = _mapper.Map<UserRoleVM>(found);

            return PartialView("PopUps/_DeleteUserRole", data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> DeleteUserRole(UserRoleVM model)
        {
            string error = await _role.DeleteUserRole(model.RoleId);

            if (string.IsNullOrEmpty(error))
                return Json(new { success = true, message = "Role Deleted Successfuly." });

            return Json(new { success = false, message = error });
        }

        #endregion

        #region home section 

        public IActionResult Index()
        {
            return View();
        }
        #endregion

    }
}