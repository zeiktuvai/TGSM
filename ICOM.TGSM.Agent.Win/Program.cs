using GameServerManager.Data;
using GameServerManager.Models.Options;
using ICOM.TGSM.Agent.Win;
using ICOM.TGSM.Service.Agent;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddWindowsService(o =>
{
    o.ServiceName = "TGSM Agent";
});
builder.WebHost.ConfigureKestrel(o =>
{
    o.ListenAnyIP(5000);
});
builder.Services.Configure<LiteDbOptions>(builder.Configuration.GetSection("LiteDbOptions"));
builder.Services.AddSingleton<LiteDbContext>();
builder.Services.AddScoped<GameServerService>();
builder.Services.AddScoped<GameServerRepository>();
builder.Services.AddScoped<SteamCMDService>();
builder.Services.AddScoped<ProcessService>();

//builder.Services.AddHostedService<AgentService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
