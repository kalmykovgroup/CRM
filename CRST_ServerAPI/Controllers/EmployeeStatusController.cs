using CSharpFunctionalExtensions;
using KTSF.Application.Service;
using KTSF.Core;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace KTSF.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeStatusController : ControllerBase
    {
        private EmployeeStatusService employeeStatusService;

        public EmployeeStatusController(EmployeeStatusService employeeStatusService)
        {
            this.employeeStatusService = employeeStatusService;
        }

        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> Insert([FromBody] string str)
        {
            EmployeeStatus employeeStatus = JsonSerializer.Deserialize<EmployeeStatus>(str);
            Result<EmployeeStatus> result = await employeeStatusService.Insert(employeeStatus);

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            result.TryGetError(out string? error);
            return NotFound(error);
        }


        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] string str)
        {
            EmployeeStatus employeeStatus = JsonSerializer.Deserialize<EmployeeStatus>(str);
            Result<EmployeeStatus> result = await employeeStatusService.Update(employeeStatus);

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
            Result<List<EmployeeStatus>> result = await employeeStatusService.GetAll();
            return Ok(result.Value);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Find(int id)
        {
            Result<EmployeeStatus> result = await employeeStatusService.Find(id);

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            result.TryGetError(out string? error);
            return NotFound(error);
        }

    }
}
