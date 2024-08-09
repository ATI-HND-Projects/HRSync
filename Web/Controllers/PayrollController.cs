using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class PayrollController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
