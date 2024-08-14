using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkyProject.BusinnessLayer.Abstract;
using MilkyProject.EntityLayer.Concrete;

namespace MilkyProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;

        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }
        [HttpGet]
        public IActionResult ListJob()
        {
            var value = _jobService.TGetListAll();
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateJob(Job job)
        {
            _jobService.TInsert(job);
            return Ok("İş Başarıyla Kaydedildi");
        }
        [HttpDelete]
        public IActionResult DeleteJob(int id)
        {
            _jobService.TDelete(id);
            return Ok("İş Başarıyla Silindi");

        }
        [HttpPut]
        public IActionResult UpdateJob(Job job)
        {
            _jobService.TUpdate(job);
            return Ok("İş Güncellendi");
        }
        [HttpGet("GetJob")]
        public IActionResult GetJob(int id)
        {
            var value=_jobService.TGetById(id); 
            return Ok(value);   
        }
    }
}
