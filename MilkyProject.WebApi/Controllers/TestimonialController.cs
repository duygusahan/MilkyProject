using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkyProject.BusinnessLayer.Abstract;
using MilkyProject.EntityLayer.Concrete;

namespace MilkyProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        [HttpGet]
        public IActionResult TestimonialList() 
        {
            var value = _testimonialService.TGetListAll();  
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateTestimonial(Testimonial testimonial) 
        {
            _testimonialService.TInsert(testimonial);
            return Ok("Referans Başarıyla Eklendi");    
        }
        [HttpDelete]
        public IActionResult DeleteTestimonial(int id)
        {
            _testimonialService.TDelete(id);
            return Ok("Referans Başarıyla Silindi");
        }
        [HttpPut]
        public IActionResult UpdateTestimonial(Testimonial testimonial)
        {
            _testimonialService.TUpdate(testimonial);
            return Ok("Referans Başarıyla Güncellendi");
        }
        [HttpGet("GetTestimonial")]
        public IActionResult GetTestimonial(int id) 
        {
            var value =_testimonialService.TGetById(id);
            return Ok(value);
        }
        [HttpGet("GetTotalTestimonialCount")]
        public IActionResult GetTotalTestimonialCount()
        {
            var value=_testimonialService.TGetTotalTestimonialCount();
            return Ok(value);   
        }
    }
}
