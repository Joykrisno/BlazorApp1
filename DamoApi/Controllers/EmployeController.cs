using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DamoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]  
    public class EmployeController : ControllerBase
    {
        public readonly IEmployeService employeService;

        public EmployeController (IEmployeService _employeService)
        {
            this.employeService = _employeService;
        }

        [HttpGet]
        [Route("GetEmployes")]
        public IActionResult GetEmployes()
        {
            var data = employeService.GetEmployes();

            return Ok(data);
        }



    }
}
