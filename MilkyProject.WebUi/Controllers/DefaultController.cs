using Microsoft.AspNetCore.Mvc;

namespace MilkyProject.WebUi.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
