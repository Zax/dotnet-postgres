using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace PostgresTestApplication
{
    public class Program
    {
        private static Lazy<IConfigurationRoot> _configuration = new Lazy<IConfigurationRoot>(BuildConfiguration);

        private static IConfigurationRoot BuildConfiguration(){
            Console.WriteLine("Carico la configurazione...");
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public static IConfigurationRoot Configuration => _configuration.Value;

        public static void Main(string[] args)
        {
        }
    }
}
