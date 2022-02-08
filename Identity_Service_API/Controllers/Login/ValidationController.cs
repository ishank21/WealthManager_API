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
            dynamic Getvalues;
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var getRole = await loginRepository.IsAuthenticated(auth.Username, auth.Password);
            if (getRole != null)
                 Getvalues = getRole.FirstOrDefault();
            else
                return NotFound();
            if (Getvalues != null)
            {
                if ((Getvalues.isvalid == 1) && (Getvalues.roletype == "Agent" || Getvalues.roletype == "Admin"))
                {
                    var user = await loginRepository.ValidateLoginDetails(auth.Username, auth.Password);
                    if (user == null)
                        return NotFound();
                    else
                        return Ok(user);
                }
                else if ((Getvalues.isvalid == 1 && (Getvalues.roletype == "Client")))
                {
                    var user = await loginRepository.ValidateclientResponses(auth.Username, auth.Password);
                    if (user == null)
                        return NotFound();
                    else
                        return Ok(user);
                }
            }
                return NotFound();
        }
        }
    }
