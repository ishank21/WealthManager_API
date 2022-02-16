using ApplicationCore.DTOs;
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

        [Route("GetClientByAgent/{agentId}")]
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
        [Route("AccountDetailByClientID/{clientId}")]
        public async Task<IActionResult> GetAccountDetailsByClientId(string clientId)
        {
            if (clientId != null)
            {
                var resp = await clientRepository.GetAccountDetailsByClientId(clientId);
                if (resp.Count > 0 && resp != null)
                {
                    return Ok(resp);
                }
                else
                    return Unauthorized("No associated Accounts with the given clientId");
            }
            else
                return BadRequest();

        }
        [HttpPost]
        [Route("InsertClientDetails")]
        public async Task<IActionResult> InsertClientDetails([FromBody] InsertClientDetailsDTO ClientDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                var insertDetails = await clientRepository.InsertClientDetails(ClientDetails);
                if (insertDetails > 0)
                {
                    return Ok("Client Successfully Inserted.");
                }
                else
                {
                    return BadRequest("Error while Adding client.");
                }
            }
        }
        [HttpPost]
        [Route("InsertClientAccountDetails")]
        public async Task<IActionResult> InsertClientAccountDetails([FromBody] InsertClientAccountDetails ClientDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                var insertDetails = await clientRepository.InsertClientAccountDetails(ClientDetails);
                if (insertDetails > 0)
                {
                    return Ok("ClientAccount Successfully Inserted");
                }
                else
                {
                    return BadRequest("Error while Adding clientAccount Detail.");
                }
            }
        }
    }
}
