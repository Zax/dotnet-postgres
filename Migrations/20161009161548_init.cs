using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Postgres.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "anagrafe",
                columns: table => new
                {
                    cod_fisc = table.Column<string>(nullable: false),
                    asl_assistenza = table.Column<string>(nullable: true),
                    codice_medico = table.Column<string>(nullable: true),
                    comune_nascita = table.Column<string>(nullable: true),
                    comune_residenza = table.Column<string>(nullable: true),
                    data_decesso = table.Column<DateTime>(nullable: true),
                    data_fine_assistenza = table.Column<DateTime>(nullable: true),
                    data_inizio_assistenza = table.Column<DateTime>(nullable: true),
                    data_nascita = table.Column<DateTime>(nullable: true),
                    data_riferimento = table.Column<DateTime>(nullable: true),
                    sesso = table.Column<string>(nullable: true),
                    stato_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_anagrafe", x => x.cod_fisc);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "anagrafe");
        }
    }
}
