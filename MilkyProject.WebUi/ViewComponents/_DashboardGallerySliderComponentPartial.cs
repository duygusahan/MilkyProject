using Microsoft.AspNetCore.Mvc;
using MilkyProject.WebUi.Dtos.GalleryDtos;
using Newtonsoft.Json;

namespace MilkyProject.WebUi.ViewComponents
{
    public class _DashboardGallerySliderComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardGallerySliderComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client =_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7272/api/Gallery");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();   
                var value=JsonConvert.DeserializeObject<List<ResultGalleryDto>>(jsonData);  
                return View(value); 
            }
            return View();
        }
    }
}
