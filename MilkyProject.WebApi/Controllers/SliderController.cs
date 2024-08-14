using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkyProject.BusinnessLayer.Abstract;
using MilkyProject.EntityLayer.Concrete;

namespace MilkyProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderService _sliderService;

        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }
        [HttpGet]
        public IActionResult ListSlider()
        {
            var value = _sliderService.TGetListAll();
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateSlider(Slider slider)
        {
            _sliderService.TInsert(slider);
            return Ok("Resim Başarıyla Eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteSlider(int id)
        {
            _sliderService.TDelete(id);
            return Ok("Resim Başarıyla Silindi");
        }
        [HttpPut]
        public IActionResult UpdateSlider(Slider slider)
        {
            _sliderService.TUpdate(slider);
            return Ok("Resim Güncellendi");
        }
        [HttpGet("GetSlider")]
        public IActionResult GetSlider(int id)
        {
            var value=_sliderService.TGetById(id);  
            return Ok(value);   
        }
    }
}
