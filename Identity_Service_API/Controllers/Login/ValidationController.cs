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
        public async Task<IActionResult> AuthenticateUser([FromBody] AuthUser auth)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var Role = await loginRepository.IsAuthenticated(auth.Username, auth.Password);
            var getRole = Role.FirstOrDefault();
            if (getRole!= null)
            {
                if ((getRole.isvalid == 1) && (getRole.roletype == "Agent" || getRole.roletype == "Admin"))
                {
                    var user = await loginRepository.ValidateLoginDetails(auth.Username, auth.Password);
                    if (user == null)
                        return NotFound();
                    else
                        return Ok(user);
                }
                else if (getRole.isvalid == 1 && getRole.roletype == "Client")
                {
                    var user = await loginRepository.ValidateclientResponses(auth.Username, auth.Password);
                    if (user == null)
                        return NotFound();
                    else
                        return Ok(user);
                }
            }
            return Unauthorized("Username or password is not correct");
        }
    }
}
