using Microsoft.AspNetCore.Mvc;

namespace MilkyProject.WebUi.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
