namespace GameServerManager.Models.Servers;

using GameServerManager.Models.Enums;
using LiteDB;
using System.Text.Json.Serialization;

[JsonDerivedType(typeof(ArmaServer), typeDiscriminator: "arma")]
[JsonDerivedType(typeof(GBServer), typeDiscriminator: "gb")]
[JsonDerivedType(typeof(OHDServer), typeDiscriminator: "ohd")]
[JsonDerivedType(typeof(SCP5KServer), typeDiscriminator: "scp")]
public class GameServer
{
    [BsonId]
    public int id { get; set; }
    public ServerTypeEnum ServerType { get; set; }
    public string ServerName { get; set; }
    public string? ServerPath { get; set; }
    public string? ServerBasePath { get; set; }
    public string? ServerWorkinDir { get; set; }
    public int Port { get; set; }
    public int QueryPort { get; set; }
    public int MaxPlayers { get; set; }
    public string? ServerPassword { get; set; }
    [JsonIgnore]
    [BsonIgnore]
    public RunningProcess? serverProc { get; set; }
    [JsonIgnore]
    [BsonIgnore]
    public int ServerPID { get; set; }
    [BsonIgnore]
    public string? PlayerStats { get; set; }
    [BsonIgnore]
    public bool IsPrivateServer { get; set; } = false;
    [BsonIgnore]
    public string? SteamAppId { get; init; }
}

