using CSharpFunctionalExtensions;
using KTSF.Application.Service;
 
using KTSF.Core.App;
using KTSF.Dto.Company_;
using KTSF.Dto.Object_;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Object = KTSF.Core.App.Object;

namespace KTSF.Api.Controllers
{ 
    namespace KTSF.Api.Controllers
    {
        [ApiController]
        [Route("[controller]")]
        [Authorize(Roles = Role.User)]
        public class ObjectController : ControllerBase
        {

            private ObjectService objectService;

            public ObjectController(ObjectService objectService)
            {
                this.objectService = objectService;
            }

             

            [HttpPost("create")]
            public async Task<IActionResult> Create([FromBody] Object @object)
            {
                Result<Object> result = await objectService.Create(@object);

                if (result.IsSuccess)
                {
                    return Ok(new ObjectCreateResponse(result.Value));
                }
                else
                {
                    return Ok(new ObjectCreateResponse(null, result.Error));
                }
            }

           

            [HttpGet("delete")]
            public async Task<IActionResult> Delete(int id)
            {
                Result<bool> result = await objectService.Delete(id);

                if (result.IsSuccess)
                {
                    return Ok(new ObjectDeleteResponse(result.Value));
                }
                else
                {
                    return Ok(new ObjectDeleteResponse(null, result.Error));
                }
            }

        }

    }
}
