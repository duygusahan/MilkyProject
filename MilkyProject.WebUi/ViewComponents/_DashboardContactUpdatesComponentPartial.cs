using Microsoft.AspNetCore.Mvc;
using MilkyProject.WebUi.Dtos.ContactDtos;
using Newtonsoft.Json;

namespace MilkyProject.WebUi.ViewComponents
{
    public class _DashboardContactUpdatesComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardContactUpdatesComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7272/api/Contact/GetLast4Contact");
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
