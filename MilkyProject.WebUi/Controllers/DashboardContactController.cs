using Microsoft.AspNetCore.Mvc;
using MilkyProject.WebUi.Dtos.ContactDtos;
using Newtonsoft.Json;

namespace MilkyProject.WebUi.Controllers
{
    public class DashboardContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DashboardContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client =_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7272/api/Contact");
            if (responseMessage.IsSuccessStatusCode) 
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var value=JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
                return View(value);
            }
            return View();
        }
    }
}
