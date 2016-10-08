using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace PostgresTestApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Carico la configurazione...");
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }
    }
}
