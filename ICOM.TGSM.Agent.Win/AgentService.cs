namespace ICOM.TGSM.Agent.Win;

public class AgentService : BackgroundService
{
    public AgentService(ILoggerFactory loggerFactory)
    { 
        Logger = loggerFactory.CreateLogger<AgentService>();
    }

    public ILogger Logger { get; }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Logger.LogInformation("Agent Service Starting.");
        stoppingToken.Register(() => Logger.LogInformation("Agent Service Stopping."));

        while (!stoppingToken.IsCancellationRequested)
        {
            Logger.LogInformation("Agent service doing something.");
            //TODO: Agent code
            await Task.Delay(5000, stoppingToken);
        }

        Logger.LogInformation("Agent Service has stopped.");
    }
}
