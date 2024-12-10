using GameServerManager.Models.Options;
using LiteDB;
using Microsoft.Extensions.Options;

namespace GameServerManager.Data
{
    public class LiteDbContext
    {
        public LiteDatabase Database { get; }

        public LiteDbContext(IOptions<LiteDbOptions> options)
        {
            string dbPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) 
                ?? throw new DirectoryNotFoundException("Application path could not be determined.");
            Database = new LiteDatabase(dbPath + options.Value.DbLocation);
        }

    }
}
