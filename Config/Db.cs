using System.Data.SqlClient;
using System.IO;
using Microsoft.Extensions.Configuration;
namespace DotNetReact.Config {
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