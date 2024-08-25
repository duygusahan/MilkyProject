using Microsoft.AspNetCore.Mvc;
using MilkyProject.WebUi.Dtos.NewsletterDtos;
using Newtonsoft.Json;
using System.Text;

namespace MilkyProject.WebUi.ViewComponents
{
    public class _NewsletterPartialComponent:ViewComponent
    {
       

        public IViewComponentResult Invoke()
        {
            return View();
        }

        

        
       
        
    }
}
