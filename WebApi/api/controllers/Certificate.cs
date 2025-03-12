using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using api.Dto;
using Microsoft.AspNetCore.Mvc;

namespace api.controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Certificate : ControllerBase
    {

    [HttpGet]
    public IActionResult Get(){
        System.Diagnostics.Debug.WriteLine("inside the controller");
        CertificateDto certificate=new CertificateDto{
            id=1,
            CourseName="C++",
            EmployeeName="Vithesh",
            StartDate=DateTime.Today,
            EndDate=DateTime.Now
        };
        return Ok(certificate);
    } 
    }
}