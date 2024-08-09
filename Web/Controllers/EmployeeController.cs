using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Attendance()
        {
            return View();
        }

        public IActionResult Leave()
        {
            return View();
        }
    }
}
