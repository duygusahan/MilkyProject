using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MilkyProject.WebUi.ViewComponents
{
    public class _DashboardServiceCountComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardServiceCountComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async  Task<IViewComponentResult> InvokeAsync()
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7272/api/Service/GetTotalServiceCount");
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
