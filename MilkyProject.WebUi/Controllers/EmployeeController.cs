using Microsoft.AspNetCore.Mvc;

namespace MilkyProject.WebUi.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
