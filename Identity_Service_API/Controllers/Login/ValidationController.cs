using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

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
            var authVal = await loginRepository.IsAuthenticated(auth.Username, auth.Password);
            var roleValue = authVal.FirstOrDefault();
            if (roleValue != null)
            {
                if (roleValue.Isvalid == 1 && (roleValue.roletype == "Agent" || roleValue.roletype == "Admin"))
                {
                    var user = await loginRepository.ValidateLoginDetails(auth.Username);
                    if (user.Count <= 0)
                        return NotFound();
                    else
                        return Ok(user);
                }
                else if (roleValue.Isvalid == 1 && roleValue.roletype == "Client")
                {
                    var user = await loginRepository.ValidateclientResponses(auth.Username);
                    if (user.Count <= 0)
                        return NotFound();
                    else
                        return Ok(user);
                }
            }
            return Unauthorized("Username or password is not correct");
        }
    }
}
