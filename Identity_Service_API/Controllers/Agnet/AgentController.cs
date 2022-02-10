using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Identity_Service_API.Controllers.Agnet
{
    [Route("api/[controller]")]
    [ApiController]
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
            if (resp.Count > 0)
            {
                return Ok(resp);
            }
            else
                return Unauthorized();
        }
    }
}
