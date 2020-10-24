using Microsoft.Extensions.Configuration;
using System.IO;

namespace InfoPortal.DAL
{
    /// TODO if this can stay. Maybe set sql commands here

    public class SQLDataAccess
    {
        public string ConnectionString { get; set; }

        public SQLDataAccess()
        {
            var configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory() + "/").AddJsonFile("appsettings.json", false)
               .Build();

            this.ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }
                
    }
}
