using GameServerManager.Models.Servers;
using ICOM.TGSM.Models.Agent.Request;
using ICOM.TGSM.Models.Agent.Response;
using ICOM.TGSM.Service.Agent;
using Microsoft.AspNetCore.Mvc;

namespace ICOM.TGSM.Agent.Win.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        public AgentController(GameServerService gameServerService)
        {
            _gss = gameServerService;
        }

        private readonly GameServerService _gss;

        [HttpGet]
        public ServerResponse GetServers()
        {
            ServerResponse response = new () { Servers = new List<GameServer>() };
            IEnumerable<GameServer> servers = _gss.GetServers();

            if (servers.Any())
            {
                response.Servers = servers.ToList();
                response.IsSuccess = true;
            }
            else
            {
                response.IsSuccess = false;
            }

            return response;
        }

        [HttpGet]
        public ServerResponse GetServer([FromBody] ServerRequest request)
        {
            ServerResponse response = new ServerResponse() { Servers = new List<GameServer>() };
            GameServer server = _gss.GetServer(request.ServerID);

            if (server == null) {
                response.IsSuccess = false; 
            } 
            else
            {
                response.Servers = new List<GameServer>() { server };
                response.IsSuccess = true;
            }

            return response;
        }

        [HttpPost]
        public void AddServer([FromBody] ServerRequest value)
        {
            if (value.Server != null)
            {
                _gss.AddNewGameServer(value.Server, value.Type);
            }           
        }

        // PUT api/<AgentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AgentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
