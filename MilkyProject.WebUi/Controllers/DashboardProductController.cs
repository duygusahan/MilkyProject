using Microsoft.AspNetCore.Mvc;
using MilkyProject.WebUi.Dtos.ProductDtos;
using Newtonsoft.Json;

namespace MilkyProject.WebUi.Controllers
{
    public class DashboardProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DashboardProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
           var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7272/api/Product/GetProductWithCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var value=JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
                return View(value);
            }
            return View();
        }
    }
}
