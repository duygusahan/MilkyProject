using Microsoft.AspNetCore.Mvc;

namespace MilkyProject.WebUi.ViewComponents
{
    public class _ContactComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
