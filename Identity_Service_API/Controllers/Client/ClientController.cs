using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Identity_Service_API.Controllers.Client
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository clientRepository;

        public ClientController(IClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetClientDetailsByAgentId(string agentId)
        {
            if (agentId!=null)
            {
                var resp = await clientRepository.GetClientDetailsForAgent(agentId);
                if (resp.Count > 0)
                {
                    return Ok(resp);
                }
                else
                    return Unauthorized("No matching Entry exist in DB with the given AgentId");
            }
            else
                return BadRequest();  
        }
        [HttpGet]
        [Route("{ClientId}")]
        public async Task<IActionResult> GetAccountDetailsByClientId(string clientId)
        {
            if (clientId != null)
            {
                var resp = await clientRepository.GetAccountDetailsByClientId(clientId);
                if (resp.Count > 0)
                {
                    return Ok(resp);
                }
                else
                    return Unauthorized();
            }
            else
                return BadRequest();

        }
    }
}
