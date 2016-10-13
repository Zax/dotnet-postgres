using System;
using System.Collections.Generic;
using System.IO;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using NpgsqlTypes;

namespace PostgresTestApplication
{
    public class Program
    {
        private static Lazy<IConfigurationRoot> _configuration = new Lazy<IConfigurationRoot>(BuildConfiguration);

        private static IConfigurationRoot BuildConfiguration()
        {
            Console.WriteLine("Carico la configurazione...");
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public static IConfigurationRoot Configuration => _configuration.Value;

        private static void ResetData(){
            using (var connection = new NpgsqlConnection(Configuration.GetConnectionString("Default")))
            {
                connection.Open();
                connection.Execute("truncate table anagrafe");
            }
        }

        public static void Main(string[] args)
        {
            int righe;
            if (args.Length == 0 || !int.TryParse(args[0], out righe))
            {
                righe = 1000;
            }
            var data = new List<Anagrafe>();
            Console.WriteLine($"Generazione dei dati ({righe} righe)...");
            for (int i = 0; i < righe; i++)
            {
                data.Add(new Anagrafe()
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
            ResetData();
            Console.WriteLine("--- EF7 ---");
            var inizio = DateTime.Now;
            using (var db = new PostgreSqlContext())
            {
                db.ChangeTracker.AutoDetectChangesEnabled = false;
                db.Anagrafe.AddRange(data);
                db.SaveChanges();
            }
            var fine = DateTime.Now;
            Console.WriteLine($"Inserite {righe} righe in {fine.Subtract(inizio).TotalSeconds} secondi.");
            ResetData();
            Console.WriteLine("--- Dapper ---");
            inizio = DateTime.Now;
            using (var connection = new NpgsqlConnection(Configuration.GetConnectionString("Default")))
            {
                connection.Open();
                connection.Execute(@"insert into anagrafe(
                    cod_fisc, data_riferimento, data_nascita, data_decesso, data_inizio_assistenza, data_fine_assistenza, sesso, stato_id, comune_nascita, comune_residenza, codice_medico, asl_assistenza) 
                    values (@cod_fisc, @data_riferimento, @data_nascita, @data_decesso, @data_inizio_assistenza, @data_fine_assistenza, @sesso, @stato_id, @comune_nascita, @comune_residenza, @codice_medico, @asl_assistenza)", data.ToArray());
            }
            fine = DateTime.Now;
            Console.WriteLine($"Inserite {righe} righe in {fine.Subtract(inizio).TotalSeconds} secondi.");
            ResetData();
            Console.WriteLine("--- Npgsql COPY ---");
            inizio = DateTime.Now;
            using (var connection = new NpgsqlConnection(Configuration.GetConnectionString("Default")))
            {
                connection.Open();
                Console.WriteLine("Salvataggio dei dati...");
                using (var writer = connection.BeginBinaryImport(@"COPY anagrafe (cod_fisc, data_riferimento, data_nascita, data_decesso, data_inizio_assistenza, data_fine_assistenza, sesso, stato_id, comune_nascita, comune_residenza, codice_medico, asl_assistenza) FROM STDIN (FORMAT BINARY)"))
                {
                    foreach (var item in data)
                    {
                        writer.StartRow();
                        writer.Write(item.cod_fisc);
                        writer.Write(item.data_riferimento, NpgsqlDbType.Date);
                        writer.Write(item.data_nascita, NpgsqlDbType.Date);
                        writer.Write(item.data_decesso, NpgsqlDbType.Date);
                        writer.Write(item.data_inizio_assistenza, NpgsqlDbType.Date);
                        writer.Write(item.data_fine_assistenza, NpgsqlDbType.Date);
                        writer.Write(item.sesso);
                        writer.Write(item.stato_id);
                        writer.Write(item.comune_nascita);
                        writer.Write(item.comune_residenza);
                        writer.Write(item.codice_medico);
                        writer.Write(item.asl_assistenza);
                    }
                }
            }
            fine = DateTime.Now;
            Console.WriteLine($"Inserite {righe} righe in {fine.Subtract(inizio).TotalSeconds} secondi.");
            ResetData();
        }
    }
}
