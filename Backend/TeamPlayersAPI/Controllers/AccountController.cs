using Common.IAuthentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TeamPlayersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        IRegisterAuthenticate _registerAuthenticate;
        ILoginAuthenticate _loginAuthenticate;
        public AccountController(IRegisterAuthenticate registerAuthenticate, ILoginAuthenticate loginAuthenticate)
        {
            _registerAuthenticate = registerAuthenticate;
            _loginAuthenticate=loginAuthenticate;
        }
        [HttpPost("signup")]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            if (!ModelState.IsValid)
                return (BadRequest(registerDTO));
            return Ok(await _registerAuthenticate.RegisterAsync(registerDTO));
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
                return (BadRequest(loginDTO));
            return Ok(await _loginAuthenticate.LogInAsync(loginDTO));
        }
    }
}
