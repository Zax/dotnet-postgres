using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using PostgresTestApplication;

namespace Postgres.Migrations
{
    [DbContext(typeof(PostgreSqlContext))]
    [Migration("20161009161548_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1");

            modelBuilder.Entity("PostgresTestApplication.Anagrafe", b =>
                {
                    b.Property<string>("cod_fisc");

                    b.Property<string>("asl_assistenza");

                    b.Property<string>("codice_medico");

                    b.Property<string>("comune_nascita");

                    b.Property<string>("comune_residenza");

                    b.Property<DateTime?>("data_decesso");

                    b.Property<DateTime?>("data_fine_assistenza");

                    b.Property<DateTime?>("data_inizio_assistenza");

                    b.Property<DateTime?>("data_nascita");

                    b.Property<DateTime?>("data_riferimento");

                    b.Property<string>("sesso");

                    b.Property<string>("stato_id");

                    b.HasKey("cod_fisc");

                    b.ToTable("anagrafe");
                });
        }
    }
}
