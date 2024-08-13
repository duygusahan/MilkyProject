using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkyProject.BusinnessLayer.Abstract;
using MilkyProject.EntityLayer.Concrete;

namespace MilkyProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsletterController : ControllerBase
    {
        private readonly INewsletterService _newsletterService;

        public NewsletterController(INewsletterService newsletterService)
        {
            _newsletterService = newsletterService;
        }
        [HttpGet]
        public IActionResult ListNewsletter() 
        {
           var value= _newsletterService.TGetListAll();
            return Ok(value);   
        }
        [HttpPost]
        public IActionResult CreateNewsletter(Newsletter newsletter)
        {
            _newsletterService.TInsert(newsletter);
            return Ok("E Mail Başarıyla Kaydedildi");    
        }
        [HttpDelete]
        public  IActionResult DeleteNewsletter(int id)
        {
            _newsletterService.TDelete(id);
            return Ok("E Mail Başarıyla Silindi");
        }
        [HttpPut]
        public IActionResult UpdateNewsletter(Newsletter newsletter) {
            _newsletterService.TUpdate(newsletter);
            return Ok("E Mail Güncellendi");
        }
        [HttpGet("GetNewsletter")]
        public IActionResult GetNewsletter(int id)
        {
            var value=_newsletterService.TGetById(id);  
            return Ok(value);
        }
    }
}
