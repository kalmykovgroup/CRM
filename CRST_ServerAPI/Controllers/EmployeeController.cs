using CSharpFunctionalExtensions; 
using KTSF.Application.Service;
using KTSF.Core;
using KTSF.Core.Product_;
using KTSF.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRST_ServerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class EmployeeController : ControllerBase
    {

         private EmployeesService employeesService; 

        public EmployeeController(EmployeesService EmployeesService)
        {
            this.employeesService = EmployeesService;
        }

        [HttpGet("{id}")]
        public IActionResult Find(int id)
        {

            Result<Employee> result = employeesService.Find(id);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }


            result.TryGetError(out string? error);

            return NotFound(error);

        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            Result<Employee[]> result = employeesService.GetAll();

             return Ok(result.Value);
        }


        [HttpPost]
        [Route("insert")]
        public IActionResult Insert(Employee employee)
        {
            Result<Employee> result = employeesService.Create(employee);

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }


            result.TryGetError(out string? error);

            return NotFound(error);
        }

        [HttpPost]
        [Route("update")]
        public IActionResult Update(Employee employee)
        {
            Result<Employee> result = employeesService.Update(employee);

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }


            result.TryGetError(out string? error);

            return NotFound(error);
        }

    }
}
