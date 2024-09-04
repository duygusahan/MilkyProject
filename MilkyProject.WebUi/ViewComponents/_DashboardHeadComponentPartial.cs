using Microsoft.AspNetCore.Mvc;

namespace MilkyProject.WebUi.ViewComponents
{
    public class _DashboardHeadComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
