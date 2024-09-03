using CSharpFunctionalExtensions;
using KTSF.Application.Service; 
using KTSF.Core.App;
using KTSF.Dto.Company_;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KTSF.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = Role.User)]
    public class CompanyController : ControllerBase
    {

        private CompanyService companyService;

        public CompanyController(CompanyService companyService)
        {
            this.companyService = companyService;
        }

        [HttpGet("all")] 
        public async Task<IActionResult> All()
        { 

           Result<List<Company>> result = await companyService.All();

            if (result.IsSuccess)
            {
                return Ok(new CompanyAllResponse(result.Value));
            }
            else
            {
                return Ok(new CompanyAllResponse(null, result.Error));
            }

           
        }

        [HttpPost("create")] 
        public async Task<IActionResult> Create([FromBody] Company company)
        {
            Result<Company> result = await companyService.Create(company);

            if (result.IsSuccess)
            {
                return Ok(new CompanyCreateResponse(result.Value));
            }
            else
            {
                return Ok(new CompanyCreateResponse(null, result.Error));
            }
        }

        [HttpGet("get")] 
        public async Task<IActionResult> Get(int id)
        {
            Result<Company> result = await companyService.Get(id);

            if (result.IsSuccess)
            {
                return Ok(new CompanyGetResponse(result.Value));
            }
            else
            {
                return Ok(new CompanyGetResponse(null, result.Error));
            }
        }

        [HttpGet("delete")] 
        public async Task<IActionResult> Delete(int id)
        {
           Result<bool> result = await companyService.Delete(id);

            if (result.IsSuccess)
            {
                return Ok(new CompanyDeleteResponse(result.Value));
            }
            else
            {
                return Ok(new CompanyDeleteResponse(null, result.Error));
            } 
        }

    }

}
