using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIDB_Secure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace APIDB_Secure
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var connString = "Server=localhost;Database=personas;Uid=root;Pwd=;";
            DBConnection.getInstance().connect(connString);

            CreateHostBuilder(args).Build().Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
