using Microsoft.AspNetCore.Mvc;
using MilkyProject.WebUi.Dtos.GalleryDtos;
using Newtonsoft.Json;
using System.Text;

namespace MilkyProject.WebUi.Controllers
{
    public class DashboardGalleryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DashboardGalleryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7272/api/Gallery");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultGalleryDto>>(jsonData);
                return View(value);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateGallery()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateGallery(CreateGalleryDto createGalleryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createGalleryDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7272/api/Gallery", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> DeleteGallery(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7272/api/Gallery?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateGallery(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7272/api/Gallery/GetGallery?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateGalleryDto>(jsonData);
                return View(value);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateGallery(UpdateGalleryDto updateGalleryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(updateGalleryDto);
            StringContent stringContent = new StringContent(jsonData,Encoding.UTF8 , "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7272/api/Gallery" , stringContent);
            if (responseMessage.IsSuccessStatusCode) 
            {
                return RedirectToAction("Index");
            }
            return View();

        }
    }
}
