using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkyProject.BusinnessLayer.Abstract;
using MilkyProject.EntityLayer.Concrete;

namespace MilkyProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdressController : ControllerBase
    {
        private readonly IAdressService _adressService;

        public AdressController(IAdressService adressService)
        {
            _adressService = adressService;
        }

        [HttpGet]
        public IActionResult ListAdress()
        {
            var value = _adressService.TGetListAll();
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateAdress(Adress adress)
        {
            _adressService.TInsert(adress);
            return Ok("Adres Başarıyla Eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteAdress(int id)
        {
            _adressService.TDelete(id);
            return Ok("Adres Başarıyla Silindi");
        }
        [HttpPut]
        public IActionResult UpdateAdress(Adress adress)
        {
            _adressService.TUpdate(adress);
            return Ok("Adres Başarıyla Güncellendi");
        }

        [HttpGet("GetAdress")]
        public IActionResult GetAdress(int id) 
        {
            var value = _adressService.TGetById(id);    
            return Ok(value);   
        }
    }
}
