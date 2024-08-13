using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkyProject.BusinnessLayer.Abstract;
using MilkyProject.EntityLayer.Concrete;

namespace MilkyProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        [HttpGet]
        public IActionResult ListContact()
        {
            var value = _contactService.TGetListAll();
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateContact(Contact contact)
        {
            _contactService.TInsert(contact);
            return Ok("İletişim Bilgileri Başarıyla Eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            _contactService.TDelete(id);
            return Ok("İletişim Bilgileri Başarıyla Silindi");
        }
        [HttpPut]
        public IActionResult UpdateContact(Contact contact)
        {
            _contactService.TUpdate(contact);
            return Ok("İletişim Bilgileri Güncellendi");
        }
        [HttpGet("GetContact")]
        public IActionResult GetContact(int id)
        {
            var value=_contactService.TGetById(id); 
            return Ok(value);
        }
    }
}
