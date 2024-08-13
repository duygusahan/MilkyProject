﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkyProject.BusinnessLayer.Abstract;
using MilkyProject.EntityLayer.Concrete;

namespace MilkyProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerController : ControllerBase
    {
        private readonly IEmployeService _employeService;

        public EmployerController(IEmployeService employeService)
        {
            _employeService = employeService;
        }
        [HttpGet]
        public IActionResult ListEmploye() 
        {
            var value = _employeService.TGetListAll();
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateEmploye(Employe employe)
        {
            _employeService.TInsert(employe);
            return Ok("Çalışan Sisteme Başarıyla Eklendi");    
        }
        [HttpDelete]
        public IActionResult DeleteEmploye(int id) 
        {
            _employeService.TDelete(id);
            return Ok("Çalışan Başarıyla Silindi");
        }
        [HttpPut]
        public IActionResult UpdateEmploye(Employe employe) 
        {
            _employeService.TUpdate(employe);
            return Ok("Çalışan Başarıyla Güncellendi");
        }

        [HttpGet("GetEmploye")]
        public IActionResult GetEmploye(int id) 
        {
            var value=_employeService.TGetById(id);
            return Ok(value);   
        }
    }
}
