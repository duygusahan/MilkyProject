using Microsoft.AspNetCore.Mvc;

namespace MilkyProject.WebUi.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
