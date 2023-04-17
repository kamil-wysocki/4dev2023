using Developers2023.Application.Interfaces;
using Developers2023.Common.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.Options;

namespace Developers2023.Api.Controllers
{
    /// <summary>
    /// Kontroler służący do autoryzacji
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly UserOption _userOption;

        public AuthController(IAuthService authService, IOptions<UserOption> userOption)
        {
            _authService = authService;
            _userOption = userOption.Value;
        }

        /// <summary>
        /// Logowanie do API
        /// </summary>
        /// <param name="username">Nazwa użytkownika</param>
        /// <param name="password">Hasło użytkownika</param>
        /// <returns></returns>
        //[EnableRateLimiting("fixed")]
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return BadRequest();

            if (username == _userOption.Username && password == _userOption.Password)
            {
                return Ok(_authService.GetToken(username, password));
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
