using Microsoft.AspNetCore.Mvc;
using MilkyProject.WebUi.Dtos;
using Newtonsoft.Json;

namespace MilkyProject.WebUi.ViewComponents
{
    public class _DashboardCategoryComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardCategoryComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7272/api/Product/GetProductCountByCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<Dictionary<string, int>>(jsonData);
                return View(value);
            }
            return View();
        }

    }
}

