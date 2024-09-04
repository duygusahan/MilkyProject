using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MilkyProject.WebUi.ViewComponents
{
    public class _FeaturesComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _FeaturesComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client =_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7272/api/Product/GetTotalProductCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<int>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
