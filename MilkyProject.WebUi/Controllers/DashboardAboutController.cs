using Microsoft.AspNetCore.Mvc;
using MilkyProject.WebUi.Dtos.AboutDtos;
using MilkyProject.WebUi.Dtos.CategoryDtos;
using Newtonsoft.Json;
using System.Text;

namespace MilkyProject.WebUi.Controllers
{
    public class DashboardAboutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DashboardAboutController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7272/api/About");
            if (responseMessage.IsSuccessStatusCode) 
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var value=JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
                return View(value);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateAbout(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7272/api/About/GetAbout?id=" + id);
            if (responseMessage.IsSuccessStatusCode) 
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateAboutDto>(jsonData);
                return View(value);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateAboutDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7272/api/About", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
