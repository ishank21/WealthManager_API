using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Identity_Service_API.Controllers.Login
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ValidationController : ControllerBase
    {
        private readonly ILoginRepository loginRepository;

        public ValidationController(ILoginRepository loginRepository)
        {
            this.loginRepository = loginRepository;
        }

        [HttpGet]
        [Route("{userName}")]
        public async Task<IActionResult> AuthenticateUser(string userName)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            { 
            var authVal = await loginRepository.IsAuthenticated(userName);

                if (authVal.Isvalid != null && authVal.roletype != null)
                {
                    if (authVal.Isvalid == 1 && (authVal.roletype == "Agent" || authVal.roletype == "Admin"))
                    {
                        var user = await loginRepository.ValidateLoginDetails(userName);
                        if (user == null)
                            return NotFound();
                        else
                            return Ok(user);
                    }
                    else if (authVal.Isvalid == 1 && authVal.roletype == "Client")
                    {
                        var user = await loginRepository.ValidateclientResponses(userName);
                        if (user == null)
                            return NotFound();
                        else
                            return Ok(user);
                    }
                }
            }
            return Unauthorized("User not found");
        }

        [Route("GetUserByName/{userName}")]
        [HttpGet]
        public async Task<IActionResult> GetUserDetailsByName(string userName)
        {
            var user = await loginRepository.ValidateLoginDetails(userName);
            if (user == null)
                return NotFound();
            else
                return Ok(user);
        }

        [Route("GetClientByName/{userName}")]
        [HttpGet]
        public async Task<IActionResult> GetClientDetailsByName(string userName)
        {
            var user = await loginRepository.ValidateclientResponses(userName);
            if (user == null)
                return NotFound();
            else
                return Ok(user);
        }
        [HttpPut]
        [Route("UpdateUserDetails")]
        public async Task<IActionResult> UpdateUserDetails([FromBody] UpdateUserDetailsDTO UserDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                var updateClient = await loginRepository.UpdateAgentDetails(UserDetails);
                if (updateClient > 0)
                {
                    return Ok("User details Successfully Updated.");
                }
                else
                {
                    return BadRequest("Error while Updating user details.");
                }
            }
        }
    }
}
