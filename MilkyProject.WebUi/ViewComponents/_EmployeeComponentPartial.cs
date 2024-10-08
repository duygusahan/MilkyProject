﻿using Microsoft.AspNetCore.Mvc;
using MilkyProject.WebUi.Dtos.EmployeeDtos;
using Newtonsoft.Json;

namespace MilkyProject.WebUi.ViewComponents
{
    public class _EmployeeComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _EmployeeComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7272/api/Employer/GetEmployeWithJob");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData= await responseMessage.Content.ReadAsStringAsync();    
                var value=JsonConvert.DeserializeObject<List<ResultEmployeWithJobDto>>(jsonData);
                return View(value);
            }
            return View();
        }
    }
}
