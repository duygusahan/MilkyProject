using Microsoft.AspNetCore.Mvc;

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
