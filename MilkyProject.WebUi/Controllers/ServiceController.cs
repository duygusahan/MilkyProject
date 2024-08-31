using Microsoft.AspNetCore.Mvc;

namespace MilkyProject.WebUi.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
