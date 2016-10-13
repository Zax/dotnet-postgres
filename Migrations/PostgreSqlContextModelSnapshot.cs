using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using PostgresTestApplication;

namespace Postgres.Migrations
{
    [DbContext(typeof(PostgreSqlContext))]
    partial class PostgreSqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<DateTime?>("data_decesso")
                        .HasColumnType("Date");

                    b.Property<DateTime?>("data_fine_assistenza")
                        .HasColumnType("Date");

                    b.Property<DateTime?>("data_inizio_assistenza")
                        .HasColumnType("Date");

                    b.Property<DateTime?>("data_nascita")
                        .HasColumnType("Date");

                    b.Property<DateTime?>("data_riferimento")
                        .HasColumnType("Date");

                    b.Property<string>("sesso");

                    b.Property<string>("stato_id");

                    b.HasKey("cod_fisc");

                    b.ToTable("anagrafe");
                });
        }
    }
}
