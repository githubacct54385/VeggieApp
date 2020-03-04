using System.Data.SqlClient;
using System.IO;
using Microsoft.Extensions.Configuration;
namespace DotNetReact.Config {
    // Class:   Db
    // Use:     Gets connection string to connectionStrings.json
    // Notes:   Please add file connectionStrings.json to root directory
    //          with connection string in the Default field otherwise
    //          this app won't be able to connect to SQL Server
    public static class Db {

        public static string ConnectionString () {
            var configuration = GetConfiguration ();
            return configuration.GetSection ("ConnectionStrings").GetSection ("Default").Value;

        }

        private static IConfigurationRoot GetConfiguration () {
            var builder = new ConfigurationBuilder ().SetBasePath (Directory.GetCurrentDirectory ()).AddJsonFile ("connectionStrings.json", optional : false, reloadOnChange : true);
            return builder.Build ();
        }

    }

}