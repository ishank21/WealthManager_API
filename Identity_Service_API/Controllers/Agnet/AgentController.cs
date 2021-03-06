using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Identity_Service_API.Controllers.Agnet
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AgentController : ControllerBase
    {
        private readonly IAgentRepository agentRepository;

        public AgentController(IAgentRepository agentRepository)
        {
            this.agentRepository = agentRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAgentDetails()
        {
            var resp = await agentRepository.GetAgentDetails();
            if (resp.Count > 0 && resp != null)
            {
                return Ok(resp);
            }
            else
                return Unauthorized();
        }
        [HttpPost]
        [Route("InsertAgentDetails")]
        public async Task<IActionResult> InsertAgentDetails([FromBody] InsertAgentDetailsDTO AgentDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                var insertDetails = await agentRepository.InsertAgentDetails(AgentDetails);
                if (insertDetails > 0)
                {
                    return Ok("Agent Successfully Inserted.");
                }
                else
                    return BadRequest("Error while Adding Agent.");
            }
        }
    }
}
