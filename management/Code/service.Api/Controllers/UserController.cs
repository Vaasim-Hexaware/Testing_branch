using System.Collections.Generic;
using service.Business.Interfaces;
using service.Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace service.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _UserService;
        public UserController(IUserService UserService)
        {
            _UserService = UserService;
        }

        // GET: api/User
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return Ok(_UserService.GetAll());
        }

        [HttpPost]
        public ActionResult<User> Save(User User)
        {
            return Ok(_UserService.Save(User));

        }

        [HttpPut("{id}")]
        public ActionResult<User> Update([FromRoute] string id, User User)
        {
            return Ok(_UserService.Update(id, User));

        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete([FromRoute] string id)
        {
            return Ok(_UserService.Delete(id));

        }


    }
}
