using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tutorial.Models.Users;
using Tutorial.Services.Interfaces;

namespace Tutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

   
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] UserModel model)
        {

            var user = await _userService.Authenticate(model.Username, model.Password);

            if (user == null)
            {
                return await Task.FromResult(new UnauthorizedResult());
            }


            return await Task.FromResult(Ok(user));

        }

    }
}
