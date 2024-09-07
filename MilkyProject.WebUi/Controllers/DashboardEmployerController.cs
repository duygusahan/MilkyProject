using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MilkyProject.DataAccessLayer.Context;
using MilkyProject.WebUi.Dtos.CategoryDtos;
using MilkyProject.WebUi.Dtos.EmployeeDtos;
using Newtonsoft.Json;
using System.Text;

namespace MilkyProject.WebUi.Controllers
{
    public class DashboardEmployerController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DashboardEmployerController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7272/api/Employer/GetEmployeWithJob");
            if (responseMessage.IsSuccessStatusCode) 
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();   
                var value=JsonConvert.DeserializeObject<List<ResultEmployeWithJobDto>>(jsonData);
                return View(value);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateEmployer()
        {
            var _context = new MilkyContext();
            var jobList = _context.Jobs
                              .Select(j => new SelectListItem
                              {
                                  Value = j.JobId.ToString(),
                                  Text = j.JobName
                              }).ToList();

            // ViewBag ile listeyi View'e gönder
            ViewBag.JobList = new SelectList(jobList, "Value", "Text");

            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployer(CreateEmployerDto createEmployerDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createEmployerDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7272/api/Employer", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteEmployer(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7272/api/Employer?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateEmployer(int id)
        {
           
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7272/api/Employer/GetEmploye?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateEmployerDto>(jsonData);
                return View(value);
            }
            var _context = new MilkyContext();
            var jobList = _context.Jobs.Select(j => new SelectListItem
            {
                Value = j.JobId.ToString(),
                Text = j.JobName
            }).ToList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateEmployer(UpdateEmployerDto updateEmployerDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateEmployerDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7272/api/Employer", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
