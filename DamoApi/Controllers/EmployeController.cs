using DamoModels.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DamoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]  
    public class EmployeController : ControllerBase
    {
     
        private readonly IEmployeService employeService;

        public EmployeController(IEmployeService employeService)
        {
            this.employeService = employeService;
        }

        [HttpGet]
        [Route("GetEmployes")]
        public IActionResult GetEmployes()
        {
            var employes = employeService.GetEmployes();
            return Ok(employes);
        }


        [HttpGet]
        [Route("DeleteEmployes")]
        public IActionResult DeleteEmployes(int employeId)
        {
            var data = employeService.DeleteEmployes(employeId);
            return Ok(data);
        }

 
        [HttpPost]
        [Route("AddNewEmploye")]
        public IActionResult AddNewEmploye(EmployeInfo info)
        {
            var response = employeService.AddNewEmploye(info);
            return Ok(response);
        }

        //[HttpPost]
        //[Route("AddNewEmploye")]
        //public IActionResult AddNewEmploye()
        //{
        //    var data = employeService.AddNewEmploye();
        //    return Ok (data);
        //}

        [HttpPut]
        [Route("UpdateEmploye")]
        public IActionResult UpdateEmploye()
        {
            var data = employeService.UpdateEmploye();
            return Ok(data);

        }

    }
}
