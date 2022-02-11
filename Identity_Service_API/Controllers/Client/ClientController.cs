using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

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
            if (agentId != null)
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
        [Route("AccountDetailByClientID")]
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
                    return Unauthorized("No associated Accounts with a given clientId");
            }
            else
                return BadRequest();

        }
    }
}
