using CRST_ServerAPI.Data;
using CRST_ServerAPI.Data.Repositories;
using KTSFClassLibrary;
using KTSFClassLibrary.Product_;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRST_ServerAPI.Controllers
{
     
    public class UserController : ApiController
    {
        public UserController(ILogger<UserController> logger) : base(logger)
        {

        }

        public override IActionResult Find(int id)
        {
            Repository repository = new UserRepository();

            var employee = repository.Find<User>(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        public override IActionResult GetAll()
        {
            Repository repository = new UserRepository();
            return Ok(repository.GetAll<User>());
        }

       

        public override IActionResult Insert<T>(int id, T obj)
        {
            throw new NotImplementedException();
        }

        public override IActionResult Update<T>(T obj)
        {
            throw new NotImplementedException();
        }
    }
}
