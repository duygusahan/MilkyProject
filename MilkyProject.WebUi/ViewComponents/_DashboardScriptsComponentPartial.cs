using Microsoft.AspNetCore.Mvc;

namespace MilkyProject.WebUi.ViewComponents
{
    public class _DashboardScriptsComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
