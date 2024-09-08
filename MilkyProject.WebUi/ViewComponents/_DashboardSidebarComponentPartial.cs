using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MilkyProject.EntityLayer.Concrete;

namespace MilkyProject.WebUi.ViewComponents
{
    public class _DashboardSidebarComponentPartial:ViewComponent
    {
       
        public IViewComponentResult Invoke()
        {
            
            return View();
        }
    }
}
