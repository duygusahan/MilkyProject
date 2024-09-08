﻿using Microsoft.AspNetCore.Mvc;
using MilkyProject.WebUi.Dtos.ServiceDtos;
using Newtonsoft.Json;
using System.Text;

namespace MilkyProject.WebUi.Controllers
{
    public class DashboardServiceController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DashboardServiceController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7272/api/Service");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);
                return View(value);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateService()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServiceDto createServiceDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createServiceDto);
            StringContent stringContent = new StringContent(jsonData ,Encoding.UTF8 ,"application/json");
            var responseMessage = await client.PostAsync("https://localhost:7272/api/Service", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
        public async Task<IActionResult> DeleteService(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7272/api/Service?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateService(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7272/api/Service/GetService?id=" + id);
            if (responseMessage.IsSuccessStatusCode) 
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value=JsonConvert.DeserializeObject<UpdateServiceDto>(jsonData);
                return View(value);
            }
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> UpdateService(UpdateServiceDto updateServiceDto)
        {
            var client= _httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(updateServiceDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7272/api/Service", stringContent);
            if (responseMessage.IsSuccessStatusCode) 
            {
                return RedirectToAction("Index");   
            }
            return View();
        }

    }
}
