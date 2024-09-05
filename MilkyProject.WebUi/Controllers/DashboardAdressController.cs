using Microsoft.AspNetCore.Mvc;
using MilkyProject.WebUi.Dtos.AboutDtos;
using MilkyProject.WebUi.Dtos.AdressDtos;
using Newtonsoft.Json;
using System.Text;

namespace MilkyProject.WebUi.Controllers
{
    public class DashboardAdressController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DashboardAdressController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7272/api/Adress");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultAdressDto>>(jsonData);
                return View(value);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAdress(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7272/api/Adress/GetAdress?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData= await responseMessage.Content.ReadAsStringAsync();
                var value=JsonConvert.DeserializeObject<UpdateAdressDto>(jsonData); 
                return View(value);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAdress(UpdateAdressDto updateAdressDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData= JsonConvert.SerializeObject(updateAdressDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7272/api/Adress", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
           
            return View();
        }
    }
}
