using CSharpFunctionalExtensions;
using KTSF.Application.Service;
using KTSF.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CRST_ServerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize]
    public class EmployeeController : ControllerBase
    {

         private EmployeesService employeesService; 

        public EmployeeController(EmployeesService EmployeesService)
        {
            this.employeesService = EmployeesService;
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> Find(int id)
        {
            Result<Employee> result = await employeesService.Find(id);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            result.TryGetError(out string? error);
            return NotFound(error);
        }


        [HttpGet("GetByEmail")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            Result<Employee> result = await employeesService.GetByEmail(email);

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            result.TryGetError(out string? error);
            return NotFound(error);
        }


        [HttpGet("GetBySurname")]
        public async Task<IActionResult> GetBySurname(string name)
        {
            Result<List<Employee>> result = await employeesService.GetBySurname(name);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            result.TryGetError(out string? error);
            return NotFound(error);
        }


        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            Result<Employee[]> result = await employeesService.GetAll();

             return Ok(result.Value);
        }


        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> Insert([FromBody] string str)
        {     
            Employee employee = JsonSerializer.Deserialize<Employee>(str);           

            Result<Employee> result = await employeesService.Create(employee);

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }

            result.TryGetError(out string? error);
            return NotFound(error);
        }


        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody]string str)
        {         
            Employee employee = JsonSerializer.Deserialize<Employee>(str)!;            

            Result<Employee> result = await employeesService.Update(employee);

            if (result.IsSuccess)
            {                
                return Ok(result.Value);
            }

            result.TryGetError(out string? error);
            return NotFound(error);
        }
    }
}
