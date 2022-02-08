using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Identity_Service_API.Controllers.Login
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidationController : ControllerBase
    {
        private readonly ILoginRepository loginRepository;

        public ValidationController(ILoginRepository loginRepository)
        {
            this.loginRepository = loginRepository;
        }
        [HttpPost]
        public async Task<IActionResult> AuthenticateUser([FromBody]AuthUser auth)
        {
            var user = loginRepository.ValidateLoginDetails(auth.Username, auth.Password);
            if (user == null)
                return NotFound();
            else
                return Ok(user);
        }
    }
}
