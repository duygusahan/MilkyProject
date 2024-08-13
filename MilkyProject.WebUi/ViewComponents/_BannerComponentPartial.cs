using Microsoft.AspNetCore.Mvc;

namespace MilkyProject.WebUi.ViewComponents
{
    public class _BannerComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();  
        }
    }
}
