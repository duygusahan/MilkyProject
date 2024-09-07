using Microsoft.AspNetCore.Mvc;
using MilkyProject.WebUi.Dtos.JobDtos;
using MilkyProject.WebUi.Dtos.NewsletterDtos;
using Newtonsoft.Json;

namespace MilkyProject.WebUi.Controllers
{
    public class DashboardNewsletterController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DashboardNewsletterController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7272/api/Newsletter");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var value=JsonConvert.DeserializeObject<List<ResultNewsletterDto>>(jsonData);
                return View(value);
            }
            return View();
        }
    }
}
