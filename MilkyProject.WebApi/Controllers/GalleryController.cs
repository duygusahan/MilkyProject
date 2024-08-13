using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkyProject.BusinnessLayer.Abstract;
using MilkyProject.EntityLayer.Concrete;

namespace MilkyProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GalleryController : ControllerBase
    {
        private readonly IGalleryService _galleryService;

        public GalleryController(IGalleryService galleryService)
        {
            _galleryService = galleryService;
        }
        [HttpGet]
        public IActionResult GalleryList()
        {
            var values = _galleryService.TGetListAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateGallery(Gallery gallery)
        {
            _galleryService.TInsert(gallery);
            return Ok("Resim Başarıyla Eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteGallery(int id)
        {
            _galleryService.TDelete(id);
            return Ok("Resim Başarıyla Silindi");
        }

        [HttpPut]
        public IActionResult UpdateGallery(Gallery gallery)
        {
            _galleryService.TUpdate(gallery);
            return Ok("Resim Başarıyla Güncellendi");
        }

        [HttpGet("GetGallery")]
        public IActionResult GetGallery(int id)
        {
            var value = _galleryService.TGetById(id);
            return Ok(value);
        }


    }
}
