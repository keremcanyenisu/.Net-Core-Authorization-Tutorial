using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tutorial.Business.Models.Users;
using Tutorial.Business.Services.Interfaces;

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

            var token = await _userService.Authenticate(model.Username, model.Password);

            if (token == null)
            {
                return await Task.FromResult(new UnauthorizedResult());
            }


            return await Task.FromResult(Ok(token));

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserModel model)
        {
            var user = await _userService.Register(model.Username, model.Password);

            if (user == null)
            {
                return await Task.FromResult(new UnauthorizedResult());
            }


            return await Task.FromResult(Ok(user));
        }

     
    }
}
