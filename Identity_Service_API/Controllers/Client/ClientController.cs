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
        [Route("{agentId}")]
        public async Task<IActionResult> GetClientDetailsByAgentId(string agentId)
        {
            if (agentId!=null)
            {
                var resp = await clientRepository.GetClientDetailsForAgent(agentId);
                if (resp != null)
                {
                    return Ok(resp);
                }
                else
                    return Unauthorized();

            }
            else
                return BadRequest();  
        }
        [HttpGet]
        public async Task<IActionResult> GetAccountDetailsByClientId(string clientId)
        {
            if (clientId != null)
            {
                var resp = await clientRepository.GetAccountDetailsByClientId(clientId);
                if (resp != null)
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
