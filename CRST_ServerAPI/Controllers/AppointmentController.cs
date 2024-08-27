using CRST_ServerAPI.Controllers;
using CSharpFunctionalExtensions;
using KTSF.Application.Service;
using KTSF.Core;
using KTSF.Core.Product_;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace KTSF.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppointmentController : ControllerBase
    {
       
        private AppointmentService appointmentService;

        public AppointmentController(AppointmentService appointmentService)
        {
            this.appointmentService = appointmentService;
        }

        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> Insert([FromBody] string str)
        {       
            Appointment appointment = JsonSerializer.Deserialize<Appointment>(str);
            Result<Appointment> result = await appointmentService.Insert(appointment);

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
            Appointment appointment = JsonSerializer.Deserialize<Appointment>(str);
            Result<Appointment> result = await appointmentService.Update(appointment);

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
            Result<List<Appointment>> result = await appointmentService.GetAll();
            return Ok(result.Value);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Find(int id)
        {
            Result<Appointment> result = await appointmentService.Find(id);

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            result.TryGetError(out string? error);
            return NotFound(error);
        }

    }
}
