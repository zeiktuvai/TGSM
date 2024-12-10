using GameServerManager.Models.Servers;

namespace ICOM.TGSM.Models.Agent.Response;

public class ServerResponse : BaseResponse
{
    public IEnumerable<GameServer> Servers { get; set; }
    public int Count { get { return Servers?.Count() ?? 0; } }
}
