using CSharpFunctionalExtensions;
using KTSF.Application.Service;
using KTSF.Core;
using Microsoft.AspNetCore.Mvc;

namespace CRST_ServerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
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


        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            Result<Employee[]> result = await employeesService.GetAll();

             return Ok(result.Value);
        }


        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> Insert(Employee employee)
        {
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
        public async Task<IActionResult> Update(Employee employee)
        {
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
