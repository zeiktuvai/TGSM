namespace ICOM.TGSM.Models.Agent.Request;

using GameServerManager.Models.Enums;
using GameServerManager.Models.Servers;
using System.Text.Json.Serialization;

public class ServerRequest
{
    public int Action { get; set; }
    public int ServerID { get; set; }
    public ServerTypeEnum Type { get; set; }
    public GameServer? Server  { get; set; }
}
