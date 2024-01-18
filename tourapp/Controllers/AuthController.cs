using Core.Interfaces.BL;
using Core.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace tourapp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        public IAuthBL authService;
        public AuthController(IAuthBL authService)
        {
            this.authService = authService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(AuthLoginRequestDto login)
        {
            try
            {
                var user = await authService.LoginUser(login);
                return Ok(user);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("adminlogin")]
        public async Task<IActionResult> AdminLogin(AuthLoginRequestDto login)
        {
            try
            {
                var user = await authService.LoginAdmin(login);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(AuthSignupRequestDto register)
        {
            try
            {
                var user = await authService.RegisterUser(register);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}