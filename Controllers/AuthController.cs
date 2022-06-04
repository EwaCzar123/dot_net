using dot_net.Data;
using dot_net.Dtos.User;
using dot_net.Models;
using Microsoft.AspNetCore.Mvc;

namespace dot_net.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController: ControllerBase
    {
        private readonly IAuthRepository _authrepository;

        public AuthController(IAuthRepository authrepository)
        {
            _authrepository = authrepository;
        }
        [HttpPost("Register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegisterDto request)
        {
            var response = await _authrepository.Register(
                new User {Username = request.Username}, request.Password
            );
            if(!response.Success){
                return BadRequest(response);
            }

            return Ok(response);
        }
         [HttpPost("Login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(UserLoginDto request)
        {
            var response = await _authrepository.Login(
                request.Username, request.Password
            );
            if(!response.Success){
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}