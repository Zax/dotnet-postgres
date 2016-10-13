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
            using (var db = new PostgreSqlContext())
            {
                db.ChangeTracker.AutoDetectChangesEnabled = false;
                int righe = 100000;
                for (int i = 0; i < righe; i++)
                {
                    db.Anagrafe.Add(new Anagrafe()
                    {
                        cod_fisc = Guid.NewGuid().ToString(),
                        data_riferimento = DateTime.Now,
                        data_nascita = new DateTime(2000, 1, 1),
                        data_decesso = DateTime.Now,
                        data_inizio_assistenza = DateTime.Now,
                        data_fine_assistenza = DateTime.Now,
                        sesso = "M",
                        stato_id = "0",
                        comune_nascita = "F205G",
                        comune_residenza = "F205G",
                        codice_medico = "MEDICO",
                        asl_assistenza = "ASL001"
                    });
                }
                var inizio = DateTime.Now;
                db.SaveChanges();
                var fine = DateTime.Now;
                Console.WriteLine($"Inserite {righe} righe in {fine.Subtract(inizio).TotalSeconds} secondi.");
            }
        }
    }
}
