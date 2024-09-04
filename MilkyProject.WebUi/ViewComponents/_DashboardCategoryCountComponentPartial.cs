using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MilkyProject.WebUi.ViewComponents
{
    public class _DashboardCategoryCountComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardCategoryCountComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client =_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7272/api/Category/GetTotalCategoryCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var value=JsonConvert.DeserializeObject<int>(jsonData);
                return View(value); 
            }
            return View();  
        }
    }
}
