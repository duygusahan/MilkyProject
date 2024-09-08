using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MilkyProject.EntityLayer.Concrete;

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
