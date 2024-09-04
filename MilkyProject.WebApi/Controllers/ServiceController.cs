using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkyProject.BusinnessLayer.Abstract;
using MilkyProject.EntityLayer.Concrete;

namespace MilkyProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }
        [HttpGet]   
        public IActionResult ServiceList()
        {
            var value=_serviceService.TGetListAll();
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateService(Service service)
        {
            _serviceService.TInsert(service);
            return Ok("Yeni Hizmet Başarıyla Eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteService(int id) 
        {
            _serviceService.TDelete(id);
            return Ok("Hizmet Başarıyla Silindi");
        }
        [HttpPut]
        public IActionResult UpdateService(Service service)
        {
            _serviceService.TUpdate(service);
            return Ok("Hizmet Başarıyla Güncellendi");
        }
        [HttpGet("GetService")]
        public IActionResult GetService(int id) 
        {
            var value=_serviceService.TGetById(id);
            return Ok(value);
        }
        [HttpGet("GetTotalServiceCount")]
        public IActionResult GetTotalServiceCount()
        {
            var value = _serviceService.TGetTotalServiceCount();
            return Ok(value);   
        }
    }
}
